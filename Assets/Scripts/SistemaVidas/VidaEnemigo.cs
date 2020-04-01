using UnityEngine;

//Control de la "vida" del enemigo

public class VidaEnemigo : MonoBehaviour
{
    public void EliminarEnemigo(GameObject other)
    {
        //si el jugador esta haciendo dash/gancho sobre el enemigo, destruimos al enemigo
        if (other != null && (other.GetComponent<Estados>().Estado() == estado.MovimientoGancho || other.GetComponent<Estados>().Estado() == estado.Dash))
        {
            gameObject.SetActive(false);
            GameManager.instance.ContadorEnemigosElim();
        }
    }
}
