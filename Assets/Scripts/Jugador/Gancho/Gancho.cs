using UnityEngine;

//Control del comportamiento del gancho a lo largo de su recorrido

public class Gancho : MonoBehaviour
{
    [SerializeField] [Range(1, 30)] float rango_gancho = 1; //longitud máxima del gancho
    [SerializeField] [Range(1, 100)] float velocidad_gancho = 1; //velocidad a la que se desplaza el gancho
    [SerializeField] [Range(0, 3)] float tiempo_desaparicion = 1; //tiempo que tarda el gancho en desaparecer
    Rigidbody2D rb_gancho = null;
    GameObject jugador = null;
    LineRenderer linea = null;
    Estados estadoJugador = null;

    void Start()
    {
        //guadamos el LineRenderer y RB del gancho
        linea = GetComponent<LineRenderer>();
        rb_gancho = GetComponent<Rigidbody2D>();
        //establecemos la velocidad a la que se mueve el gancho
        rb_gancho.AddForce(transform.right * velocidad_gancho, ForceMode2D.Impulse);
        //anulamos la gravedad y drag para que no afecten a la direccion y velocidad del gancho
        rb_gancho.gravityScale = 0;
        rb_gancho.drag = 0;
        rb_gancho.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    void Update()
    {
        //dibujamos la linea del gancho al jugador
        linea.SetPosition(0, Posicion(jugador.transform.position));
        linea.SetPosition(1, Posicion(transform.position));

        //si la longitud de la linea supera al rango máximo (falla)
        if ((linea.GetPosition(1) - linea.GetPosition(0)).magnitude > rango_gancho)
        {
            DestruirGancho(); //se destruye el gancho
        }
    }

    void OnTriggerEnter2D(Collider2D collision) //si el gancho entra en contacto con algo distinto del jugador, se activa el gancho
    {
        GameObject colision = collision.gameObject;
        if (colision.GetComponent<Jugador>() == null && colision.GetComponent<Suelo>() == null) //si no ha colisionado con el jugador
        {
            if (colision.layer != 13 && colision.layer != 16) //La capa 13 es en la que estarán los objetos no enganchables
            {
                Destroy(rb_gancho); //ddetenemos el movimiento del gancho
                jugador.GetComponent<Jugador>().Gancho(gameObject); //guardamos una referencia del gancho
                estadoJugador.CambioEstado(estado.MovimientoGancho); //cambiamos el estado a "MovimientoGancho"
            }
            else if (colision.layer == 13)
            {
                DestruirGancho(); //si colisiona con algo con lo que no puede engancharse, se comporta como si hubiese
            }
        }

    }

    Vector3 Posicion(Vector3 vector) //método para la conversion a Vector3, porque la naturaleza 3D del LineRenderer requiere que la 'z' sea -1
    {
        return new Vector3(vector.x, vector.y, -1);
    }

    void DestruirGancho() //método de destrucción del RB y el collider, para detener el movimiento y evitar que se active el gancho
    {
        Destroy(rb_gancho);
        Destroy(GetComponent<BoxCollider2D>());
        Invoke("Destruir", tiempo_desaparicion); //tras pasar cierto tiempo, se destruye definitivamente el objeto
    }

    void Destruir() //método que destruye todo el objeto
    {
        Destroy(gameObject);
        estadoJugador.CambioEstado(estado.Defecto); //cambiamos el estado a por defecto
    }

    public void CreacionGancho(GameObject referenciaJugador) //método que asigna referencias al jugador y estados desde "CreaGancho"
    {
        jugador = referenciaJugador;
        estadoJugador = jugador.GetComponent<Estados>();
    }

    //métodos utilizados para el PowerUp "AlargaGancho"
    public float GetLongitudGancho() //método que devuelve la longitud recorrida por el gancho
    {
        return rango_gancho;
    }

    public void PowerUpGancho(float nueva_longitud_gancho) //método que actualiza la longitud del gancho
    {
        rango_gancho = nueva_longitud_gancho;
    }
}
