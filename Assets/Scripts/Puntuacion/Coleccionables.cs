using UnityEngine;

public class Coleccionables : MonoBehaviour
{
    [SerializeField] int numeroColeccionable = 0; //numero del coleccionable
    
    void OnTriggerEnter2D(Collider2D other) //en caso de colisionar con el jugador
    {
        if(other.gameObject.GetComponent<VidaJugador>() != null)
        {
            GameManager.instance.Coleccionable(numeroColeccionable); //activamos el booleano
            Destroy(gameObject); //destruimos el objeto
        }
    }
}
