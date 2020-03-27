using UnityEngine;

public class Gancho : MonoBehaviour
{
    //Script que tendrá el gancho y controla como se comporta en su recorrido

    [SerializeField] [Range (1,30)]  float rango_gancho = 1; //Longitud máxima del gancho
    [SerializeField] [Range(1, 100)] float velocidad_gancho = 1; //Velocidad a la que se desplaza el gancho
    [SerializeField] [Range(0, 3)] float tiempo_desaparicion = 1; //Tiempo que tarda el gancho en desaparecer

    Rigidbody2D rb_gancho = null;
    GameObject jugador = null;
    LineRenderer linea = null;
    Estados estadoJugador = null;
    bool antigancho = false;

    private void Start()
    {
        linea = GetComponent<LineRenderer>();
        rb_gancho = GetComponent<Rigidbody2D>();
        rb_gancho.AddForce(transform.right * velocidad_gancho, ForceMode2D.Impulse); //velocidad a la que se mueve el gancho
        rb_gancho.gravityScale = 0;
        rb_gancho.drag = 0; //Anulamos la gravedad y drag para que no afecten a la direccion y velocidad del gancho
    }
    private void Update()
    {
        linea.SetPosition(0, Posicion(jugador.transform.position));
        linea.SetPosition(1,Posicion(transform.position)); //Dibujamos la linea del gancho al jugador

        if((linea.GetPosition(1) - linea.GetPosition(0)).magnitude > rango_gancho) //Si la longitud de la linea supera al rango máximo se destruye el gancho
        {
            DestruirGancho();
        }
    }
    Vector3 Posicion(Vector3 vector) //Debido a la naturaleza 3d del LineRendered hay que dibujarlo en la posición -1 de z para que se vea encima de los sprites
    {
        return new Vector3(vector.x, vector.y, -1); 
    }
    void DestruirGancho() //Se detruye el rigid body para detener el movimiento y el box collider para evitar que se active el gancho al llegar al final
    {
        Destroy(rb_gancho);
        Destroy(GetComponent<BoxCollider2D>());
        Invoke("Destruir", tiempo_desaparicion); //Una vez pasado el tiempo de desaparición se destruye definitivamente el objeto
    }
    void Destruir()
    {
        Destroy(gameObject);
        estadoJugador.CambioEstado(estado.Defecto); //El estado cambia al por defeco
    }
    public void CreacionGancho(GameObject referenciaJugador) //Es el método que usa "CreaGancho" para asignar la referencia del jugador y los estados
    {
        jugador = referenciaJugador;
        estadoJugador = jugador.GetComponent<Estados>();
    }

    private void OnTriggerEnter2D(Collider2D collision) //Si el gancho entra en contacto con algo distinto del jugador se activa el gancho
    {
        GameObject colision = collision.gameObject;
        if (colision.GetComponent<Jugador>() == null && colision.GetComponent<Suelo>() == null) //Suelo es el componente que tienen los pies del jugador
        {
            if (colision.layer != 13 && colision.layer != 16) //La capa 13 es en la que estarán los objetos no enganchables
            {
                Destroy(rb_gancho); //Detenemos el movimiento del gancho
                jugador.GetComponent<Jugador>().Gancho(gameObject); //Asginamos una referencia del gancho al script Jugador
                estadoJugador.CambioEstado(estado.MovimientoGancho); //Cambiamos el estado a movimiento gancho
            }
            else if(colision.layer == 13)
            {
                DestruirGancho(); //Si colisiona con algo con lo que no puede engancharse pasa lo mismo que si se hubiera fallado
            }
        }
    }
    //PowerUP gancho alargado
    public float ValorInicial() //devuelve el valor inicial de la longitud gancho
    {
        return rango_gancho;
    }
    public void PowerUpGancho(float nueva_longitud_gancho) //Cambia el valor de la longitud del gancho
    {
        rango_gancho = nueva_longitud_gancho;
    }
}
