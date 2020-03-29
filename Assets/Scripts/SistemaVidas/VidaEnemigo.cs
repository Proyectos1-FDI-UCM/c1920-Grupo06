using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    public void EliminarEnemigo(GameObject other)  //si es enemigo/obstaculo
    {
        //si el jugador esta haciendo dash/gancho, destruimos al enemigo
        if (other != null && (other.GetComponent<Estados>().Estado() == estado.MovimientoGancho || other.GetComponent<Estados>().Estado() == estado.Dash))
        {
            gameObject.SetActive(false);
            GameManager.instance.Contadorenemieselim();
        }
    }
}
