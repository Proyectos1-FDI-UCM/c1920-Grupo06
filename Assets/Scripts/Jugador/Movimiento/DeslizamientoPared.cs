using UnityEngine;

//Comportamiento del deslizamiento del jugador en las paredes
public enum posicionColliders
{ derecha, izquierda, ninguna };

public class DeslizamientoPared : MonoBehaviour
{
    [SerializeField] float velocidad_Deslizamiento = -2.5f;
    //Posiciones posbiles de un trigger que esta chocando con algo: ninguna si no choca con nada
    //Se inicializa a ninguna, no se esta chocando con nada al comienzo del juego
    posicionColliders posicionCollider = posicionColliders.ninguna;

    //Array que contiene los dos colliders derecho e izquierdo (en el mismo orden que están colocados en el editor)
    BoxCollider2D[] colliders;
    Rigidbody2D rb;
    Estados estadoJugador;
    BoxCollider2D boxCollider2D;
    PlatformEffector2D jumpthrough;
    CompositeCollider2D compositeCollider2D;

    public posicionColliders GetCollider
    {
        get { return posicionCollider; }
    }
    void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody2D>();
        estadoJugador = transform.parent.GetComponent<Estados>();
        colliders = gameObject.GetComponents<BoxCollider2D>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        GameObject objeto = other.gameObject;
        boxCollider2D = objeto.GetComponent<BoxCollider2D>();
        jumpthrough = objeto.GetComponent<PlatformEffector2D>();
        compositeCollider2D = objeto.GetComponent<CompositeCollider2D>();

        //Si el gameObject con el que se choca tiene el componente PlataformaJumpthrough, no se produce deslizamiento para evitar errores
        if (jumpthrough == null && (compositeCollider2D != null || (boxCollider2D != null && !boxCollider2D.isTrigger)))
        {
            //Si el jugador no esta en otro estado que sea propio de otro movimiento, se produce el deslizamiento
             if (rb.velocity.y <= 0 && (estadoJugador.Estado() == estado.SlowMotion || estadoJugador.Estado() == estado.Defecto))
            {
                rb.velocity = new Vector2(rb.velocity.x, velocidad_Deslizamiento);
                //Se indica la posición del trigger que ha chocado con algo
                if (colliders[0].IsTouching(other))
                {
                    posicionCollider = posicionColliders.derecha;
                }
                else if (colliders[1].IsTouching(other))
                {
                    posicionCollider = posicionColliders.izquierda;
                }
            }
        }
    }

    //Al salir del trigger se restablece la posición a ningún trigger esta chocando.
    private void OnTriggerExit2D(Collider2D collision)
    {
        posicionCollider = posicionColliders.ninguna;
    }

    //Método que devuelve la posición del trigger que está chocando con algo
    public string direccionDeslizamiento()
    {
        Debug.Log(posicionCollider);
        return posicionCollider.ToString();
    }
}
