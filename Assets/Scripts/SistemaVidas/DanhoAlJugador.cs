using UnityEngine;

public class DanhoAlJugador : MonoBehaviour
{
    private void OnTriggerEnter2D (Collider2D other) //enemigo "trigger" porque si no, alteramos su velocidad
    {
        VidaJugador vida = other.gameObject.GetComponent<VidaJugador>(); //si detecta a una entidad con vida

        if (vida != null) //si detecta al jugador
        {
            vida.EliminaVidaJugador(); //llamamos al metodo de quitar vida del jugador    
        }
    }
}
