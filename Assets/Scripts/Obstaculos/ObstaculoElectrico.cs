using UnityEngine;

//Comportamiento de "ObstáculoElectrico"

public class ObstaculoElectrico : MonoBehaviour
{
    [SerializeField] GameObject jugador = null; //referencia al jugador

    void OnTriggerEnter2D(Collider2D other) //cuando algo colisione con él
    {
        if (other.gameObject.GetComponent<Gancho>() != null) //si es el gancho
        {
            jugador.GetComponent<VidaJugador>().EliminaVidaJugador(); //quitamos una vida al jugador
        }
    }
}
