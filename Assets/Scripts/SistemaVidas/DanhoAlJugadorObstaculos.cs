using UnityEngine;

//Comportamiento del daño que se le hace al jugador (enemigos, obstáculos)

public class DanhoAlJugadorObstaculos : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        VidaJugador vida = other.gameObject.GetComponent<VidaJugador>(); //comprobamos si detecta a una entidad con vida (jugador)
        Salto salto = other.gameObject.GetComponent<Salto>(); //comprobamos si detecta a una entidad con vida (jugador)

        if (vida != null) //si detecta al jugador
        {
            vida.EliminaVidaJugador(); //llamamos al metodo de quitar vida del jugador    
            salto.Knockback(transform.position);
        }
    }
}
