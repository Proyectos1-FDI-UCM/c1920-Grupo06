using UnityEngine;

//Comportamiento del Dash

public class Dash : MonoBehaviour
{
    //longitud y velocidad del Dash
    [SerializeField] [Range(0, 50)] float longitudDash = 5;
    [SerializeField] [Range(0, 50)] float velocidadDash = 5;
    Estados estadoJugador;
    Jugador jugador;
    Rigidbody2D rb;
    Vector3 posicion_inicial = Vector3.zero; //vector posicion inicial del jugador
    Vector3 direccion = Vector3.up; //vector direccion del dash
    Suelo suelo;

    AudioSource aud;

    void Awake()
    {
        //inicializamos las referencias 
        rb = GetComponent<Rigidbody2D>();
        estadoJugador = GetComponent<Estados>();
        jugador = GetComponent<Jugador>();
        //desactivamos el script en caso de estar activado
        enabled = false;

        suelo = transform.GetChild(0).GetComponent<Suelo>();
        aud = GetComponent<AudioSource>();
    }

    void OnEnable() //cuando se active el Dash
    {
        //creamos un vector direccion del Dash con respecto al jugador y la direccion seleccionada
        posicion_inicial = transform.position;
        rb.velocity = Vector2.zero;
        Vector3 direccionAux = jugador.DireccionDash();
        //actualizamos la direccion del Dash
        if (direccionAux != Vector3.zero)
            direccion = direccionAux;
        if (!(direccion.y < 0 && suelo.EnSuelo()))
        {
            aud.Play();
            rb.AddForce(direccion.normalized * velocidadDash, ForceMode2D.Impulse); //establecemos una fuerza en esa dirección
        }
        else
        {
            aud.Stop();
            enabled = false; //Desactivamos el Dash
            Invoke("CambiaEstadoRetardado", 0.1f);
        }
    }

    void Update()
    {
        if ((transform.position - posicion_inicial).magnitude > longitudDash) //si se ha alcanzado la distancia 
            enabled = false; //Desactivamos el Dash
    }

    void OnCollisionEnter2D(Collision2D collision) //en caso de colisionar con alguna entidad (plataformas)
    {
        enabled = false; //lo desactivamos
    }

    void OnDisable() //cuando se desactive el Dash
    {
        rb.velocity = Vector2.zero; //establecemos la velocidad a 0
        if (estadoJugador.Estado() != estado.Defecto) //en caso de ejecutarse el Awake antes
        {
            estadoJugador.CambioEstado(estado.Defecto); //cambiamos a estado por defecto
        }
    }

    //métodos utilizados para el PowerUp "SaltoPotenciado"
    public float GetLongitudDash() //método que devuelve la longitud recorrida por el dash
    {
        return longitudDash;
    }

    public void PowerUpDash(float nueva_longitud) //método que actualiza la longitud del Dash
    {
        longitudDash = nueva_longitud;
    }
    void CambiaEstadoRetardado()
    {
        estadoJugador.CambioEstado(estado.Defecto); //establecemos el estado a defecto ; 
    }
}
