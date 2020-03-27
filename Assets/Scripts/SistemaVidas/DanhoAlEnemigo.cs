using UnityEngine;

public class DanhoAlEnemigo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) //enemigo "trigger" porque si no, alteramos su velocidad
    {
        VidaEnemigo aux = other.gameObject.GetComponent<VidaEnemigo>();

        if (aux != null) //si detecta al enemigo
        {
            aux.EliminarEnemigo(gameObject); //llamamos al metodo de eliminar al enemigo
        }
    }
}
