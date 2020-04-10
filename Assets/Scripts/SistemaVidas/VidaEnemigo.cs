using UnityEngine;

//Control de la "vida" del enemigo

public class VidaEnemigo : MonoBehaviour
{
    [SerializeField] Estadísticas estadisticas = null;
    public void EliminarEnemigo(GameObject other)
    {
        //si el jugador esta haciendo dash/gancho sobre el enemigo, destruimos al enemigo
        if (other != null && (other.GetComponent<Estados>().Estado() == estado.MovimientoGancho || other.GetComponent<Estados>().Estado() == estado.Dash))
        {
            estadisticas.Enemigo(); //Sumamos uno a enemigos derrotados
            gameObject.SetActive(false);
            GameManager.instance.ContadorEnemigosElim();
        }
    }
}
