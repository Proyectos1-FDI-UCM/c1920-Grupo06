using UnityEngine;

//Control de la pantalla de final del nivel

public class FinalDelNivel : MonoBehaviour
{
    //tiempo que subirá la cámara hasta que aparezca la pantalla de puntuación
    [SerializeField] [Range(0, 5)] float tiempo = 0f;

    void OnTriggerEnter2D(Collider2D collision) //trigger al final del nivel para la información de puntuación
    {
        if (collision.gameObject.GetComponent<VidaJugador>() != null) //si el jugador llega al final
        {
            //lo establecemos como "player"
            GameManager.instance.SetJugador(collision.gameObject);
            Invoke("LlamaAlMetodoPuntuacion", tiempo); //llamamos al metodo de aparición de la pantalla de puntuación
        }
    }

    void LlamaAlMetodoPuntuacion() //método que muestra la información de la puntuación en pantalla
    {
        GameManager.instance.Puntuacion(); //llamamos al método del GM que se encarga de mostrar la información
        gameObject.SetActive(false); //desactivamos el trigger
    }
}