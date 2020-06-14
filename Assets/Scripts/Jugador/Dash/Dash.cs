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
    PlatformEffector2D jumpthrough;
    AudioSource aud;
    AudioSource[] audAux;
    int cont = 0;

    PlataformaAgrietada rompible = null;

    bool ignore = false;
    PlataformaMovible movible = null;


    void Awake()
    {
        //inicializamos las referencias 
        rb = GetComponent<Rigidbody2D>();
        estadoJugador = GetComponent<Estados>();
        jugador = GetComponent<Jugador>();
        //desactivamos el script en caso de estar activado
        enabled = false;

        suelo = transform.GetChild(0).GetComponent<Suelo>();
        audAux = GetComponentsInChildren<AudioSource>();
        aud = audAux[Metodos.EncuentraAudioSource(audAux, "Dash")];
    }

    void OnEnable() //cuando se active el Dash
    {
        //creamos un vector direccion del Dash con respecto al jugador y la direccion seleccionada
        rb.isKinematic = false;
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
        Invoke("ParaDash", 4f);
    }

    private void FixedUpdate()
    {
        if ((transform.position - posicion_inicial).magnitude > longitudDash) //si se ha alcanzado la distancia 
            enabled = false;
        if (rb.velocity == Vector2.zero && rompible == null) ParaDash();
        else
        {
            rb.velocity = direccion.normalized * velocidadDash;
            rompible = null;
        }
    }

    void OnCollisionEnter2D(Collision2D collision) //en caso de colisionar con alguna entidad (plataformas)
    {
        rompible = collision.gameObject.GetComponentInChildren<PlataformaAgrietada>();
        jumpthrough = collision.gameObject.GetComponent<PlatformEffector2D>();
        movible = collision.gameObject.GetComponent<PlataformaMovible>();

        if (movible != null && direccion.y >= 0 && transform.position.y > movible.transform.position.y) ignore = true;

        if (jumpthrough == null && enabled && !ignore)
        {
            rb.velocity = Vector2.zero;
            ParaDash();
        }
        else if (jumpthrough != null && direccion.y < 0 && enabled && !ignore)
        {
            rb.velocity = Vector2.zero;
            ParaDash();
        }
    }

    void OnCollisionStay2D(Collision2D collision) //en caso de colisionar con alguna entidad (plataformas)
    {
        if (!suelo.EnSuelo() && jumpthrough == null && !ignore)
        {
            ParaDash();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        movible = collision.gameObject.GetComponent<PlataformaMovible>();
        if (movible != null) { ignore = false; movible = null; }
    }


    void OnDisable() //cuando se desactive el Dash
    {
        jumpthrough = null;
        rb.velocity = Vector2.zero; //establecemos la velocidad a 0
        if (estadoJugador.Estado() != estado.Defecto) //en caso de ejecutarse el Awake antes
        {
            estadoJugador.CambioEstado(estado.Defecto); //cambiamos a estado por defecto
        }
        cont = 0;
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

    void ParaDash() //método utilizado para ignorar las primeras colisiones del Dash
    {
        if (cont > 5)
        {
            enabled = false;
            cont = 0;
        }
        else cont++;
    }

    public void ReDashea()
    {
        rb.AddForce(direccion.normalized * velocidadDash, ForceMode2D.Impulse); //establecemos una fuerza en esa dirección
    }
}
