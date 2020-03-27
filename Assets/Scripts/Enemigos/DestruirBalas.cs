using UnityEngine;

public class DestruirBalas : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        VidaJugador aux = collision.transform.GetComponent<VidaJugador>();

        if (aux != null)
        {
            aux.EliminaVidaJugador();
        }

        Destroy(gameObject);
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
