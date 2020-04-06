using UnityEngine;

//Comportamiento del deslizamiento del jugador en las paredes

public class DeslizamientoPared : MonoBehaviour
{
    [SerializeField] float velocidad_Deslizamiento = -2.5f;
    [SerializeField] BoxCollider2D triggerDeslizamiento;
    Rigidbody2D rb;
    Estados estadoJugador;

    void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody2D>();
        estadoJugador = transform.parent.GetComponent<Estados>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        //Si el gameObject con el que se choca tiene el componente PlataformaJumpthrough, no se produce deslizamiento para evitar errores
        if (other.gameObject.GetComponent<PlataformaJumpthrough>() == null && !other.gameObject.GetComponent<BoxCollider2D>().isTrigger)
        {
            //Si el jugador no esta en otro estado que sea propio de otro movimiento, se produce el deslizamiento
            if (rb.velocity.y <= 0 && (estadoJugador.Estado() == estado.SlowMotion || estadoJugador.Estado() == estado.Defecto))
            {
                rb.velocity = new Vector2(rb.velocity.x, velocidad_Deslizamiento);
            }
        }
    }
}
