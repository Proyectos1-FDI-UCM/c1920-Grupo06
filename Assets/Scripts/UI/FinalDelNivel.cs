using UnityEngine;

public class FinalDelNivel : MonoBehaviour
{
    [SerializeField] [Range(0, 5)] float tiempo = 0f;
    //trigger al final del nivel para cambiar de escena donde aparecerá la información post-nivel
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<VidaJugador>() != null)
        {
            GameManager.instance.SetPlayer(collision.gameObject);
            Invoke("LlamaAlMetodoPuntuacion", tiempo);
        }
    }
    private void LlamaAlMetodoPuntuacion()
    {
        GameManager.instance.Puntuation();
        gameObject.SetActive(false);
    }
}