using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField] [Range(0, 50)] float longitudDash = 5;
    [SerializeField] [Range(0, 50)] float velocidadDash = 5;

    Estados estadoJugador;
    Jugador jugador;
    Rigidbody2D rb;
    Vector3 posicion_inicial = Vector3.zero;
    Vector3 direccion = Vector3.up;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        estadoJugador = GetComponent<Estados>();
        jugador = GetComponent<Jugador>();
        enabled = false;
    }

    private void OnEnable()
    {
        posicion_inicial = transform.position;
        rb.velocity = Vector2.zero;
        Vector3 direccionAux = jugador.DireccionDash();
        if (direccionAux != Vector3.zero)
            direccion = direccionAux;
        rb.AddForce(direccion.normalized * velocidadDash, ForceMode2D.Impulse);
    }
    private void Update()
    {
        if ((transform.position - posicion_inicial).magnitude > longitudDash)
            enabled = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        enabled = false;
    }
    private void OnDisable()
    {
        rb.velocity = Vector2.zero;
        if (estadoJugador.Estado() != estado.Defecto) //en caso de ejecutarse el Awake antes
        {
            estadoJugador.CambioEstado(estado.Defecto);
        }
    }

    //PowerUp aumento dash
    public float GetLongitudDash()
    {
        return longitudDash;
    }

    public void PowerUpDash(float nueva_longitud)
    {
        longitudDash = nueva_longitud;
    }
}
