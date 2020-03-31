using UnityEngine;

//Comportamiento de las balas ante una colision

public class DestruirBalas : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision) //comprobamos la colisión de la bala
    {
        VidaJugador aux = collision.transform.GetComponent<VidaJugador>();

        if (aux != null) //si ha chocado con el jugador
        {
            aux.EliminaVidaJugador(); //eliminamos una de sus vidas
        }

        Destroy(gameObject); //destruimos la bala
    }

    void OnBecameInvisible() //en caso de que salga de pantalla, destruimos la bala
    {
        Destroy(gameObject);
    }
}
