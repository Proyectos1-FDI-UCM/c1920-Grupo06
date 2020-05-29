using UnityEngine;

//Control de la "vida" del enemigo

public class VidaEnemigo : MonoBehaviour
{
    public void EliminarEnemigo(GameObject other)
    {
        //si el jugador esta haciendo dash/gancho sobre el enemigo, destruimos al enemigo
        Estados estados = other.GetComponent<Estados>();
        if (other != null && estados.Estado() == estado.Dash)
        {
            other.GetComponent<Jugador>().estadisticas.Enemigo(); //Sumamos uno a enemigos derrotados
            gameObject.SetActive(false);
            GameManager.instance.ContadorEnemigosElim();

        }
    }
}
