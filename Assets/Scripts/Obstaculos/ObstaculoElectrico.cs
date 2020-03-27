using UnityEngine;

//Hay que configurar el obstáculo eléctrico como layer NoEnganchable
public class ObstaculoElectrico : MonoBehaviour
{
    [SerializeField] GameObject jugador = null;
    VidaJugador vidaJugador;

    private void Start()
    {
        vidaJugador = jugador.GetComponent<VidaJugador>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Gancho>() != null)
        {
            vidaJugador.EliminaVidaJugador();
        }
    }
}
