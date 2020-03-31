using UnityEngine;

//Control de la vida del jugador

public class VidaJugador : MonoBehaviour
{
    [SerializeField] float tiempoInvulnerable = 3f; //tiempo de invulnerabilidad
    bool invulnerable = false; //booleano de invulnerabilidad 

    public void EliminaVidaJugador() //método para la eliminación de vidas
    {
        Estados estados = GetComponent<Estados>();

        //si el jugador no es invulnerable, y no está moviendose con el dash/gancho
        if (estados != null && !invulnerable && estados.Estado() != estado.MovimientoGancho && estados.Estado() != estado.Dash)
        {
            if (GameManager.instance != null) //si hay GM
            {
                GameManager.instance.EliminaVidaJugador(); //quita una vida

                if (transform.position != GameManager.instance.CheckPoint()) //si no ha muerto
                {
                    invulnerable = true; //lo hacemos invulnerable
                    Invoke("HacerVulnerable", tiempoInvulnerable); //en 'x' tiempo, volverá a ser vulnerable
                }
            }
        }
    }

    public void HacerVulnerable() //método que permite hacer que el jugador vuelva a ser vulnerable
    {
        invulnerable = false; //pasa a ser vulnerable
    }

    public void HacerInvulnerable() //método que permite hacer que el jugador vuelva a ser invulnerable
    {
        invulnerable = true; //pasa a ser invulnerable
    }
}
