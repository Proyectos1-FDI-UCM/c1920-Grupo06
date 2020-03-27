using UnityEngine;

public class Impulso : MonoBehaviour
{
    //Este es un script que no se desactiva por el componente Estado porque se ejecuta una única vez
    //por lo que no es necesario

    [SerializeField][Range(0,2)] float fuerza_impulso = 5; //Fuerza en la que se impulsará el jugador
    Rigidbody2D rb;
    Estados estadoJugador;
    Jugador jugador;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        estadoJugador = GetComponent<Estados>();
        jugador = GetComponent<Jugador>();
    }

    public void ImpulsoGancho()
    {
        rb.velocity /= 2.5f; //La velocidad que tenia el jugador del movimiento del gancho se reduce a la mitad para conservar algo de momento
        Vector3 direccion = jugador.DireccionImpulso(); direccion.y += 1; //"Jugador" tiene un metodo con la dirección a la que debería desplazarse el gancho
        rb.AddForce(direccion.normalized * fuerza_impulso, ForceMode2D.Impulse); //Se añade el impulso
        estadoJugador.CambioEstado(estado.Defecto); //Se cambia el estado de vuelta al por defecto
    }
}
