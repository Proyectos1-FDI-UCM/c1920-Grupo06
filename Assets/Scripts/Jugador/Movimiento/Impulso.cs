using UnityEngine;

//Comportamiento del impulso del jugador (no se desactiva por Estados pues se ejecuta solo una vez)

public class Impulso : MonoBehaviour
{
    [SerializeField] [Range(0, 2)] float fuerza_impulso = 5; //fuerza en la que se impulsará el jugador
    Rigidbody2D rb;
    Estados estadoJugador;
    Jugador jugador;

    void Start()
    {
        //inicializamos las referencias
        rb = GetComponent<Rigidbody2D>();
        estadoJugador = GetComponent<Estados>();
        jugador = GetComponent<Jugador>();
    }

    public void ImpulsoGancho() //método que establece el impulso que ejecuta el jugador al usar el gancho
    {
        rb.velocity /= 2.5f; //se reduce la velocidad que tenia el jugador del movimiento del gancho para conservar algo de momento
        //dirección a la que se tiene que desplazar con respecto a la posición del gancho
        Vector3 direccion = jugador.DireccionImpulso(); direccion.y += 1;
        rb.AddForce(direccion.normalized * fuerza_impulso, ForceMode2D.Impulse); //se establece la fuerza del impulso
        estadoJugador.CambioEstado(estado.Defecto); //se vuelve al estado por defecto
    }
}
