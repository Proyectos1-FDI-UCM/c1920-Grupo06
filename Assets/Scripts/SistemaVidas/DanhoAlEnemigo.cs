using UnityEngine;

//Comportamiento del daño que hace el jugador

public class DanhoAlEnemigo : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        VidaEnemigo aux = other.gameObject.GetComponent<VidaEnemigo>(); //comprobamos si ha chocado con un enemigo

        if (aux != null) //si detecta al enemigo
        {
            aux.EliminarEnemigo(gameObject); //llamamos al metodo de eliminar al enemigo
        }
    }
}
