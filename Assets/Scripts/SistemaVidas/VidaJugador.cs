using UnityEngine;

public class VidaJugador : MonoBehaviour
{
    bool invulnerable = false;
    [SerializeField] float tiempoInvulnerable = 3f;
    //float timeToFade;

    public void EliminaVidaJugador() //método para la eliminación de vidas
    {
        Estados estados = GetComponent<Estados>();

        if (estados != null) //si es el jugador
        {
            if (!invulnerable && estados.Estado() != estado.MovimientoGancho && estados.Estado() != estado.Dash)
            {
                if (GameManager.instance != null) //si hay GM
                {
                    GameManager.instance.EliminaVidaJugador(); //quita una vida

                    if (transform.position != GameManager.instance.CheckPoint()) //si no ha muerto
                    {
                        invulnerable = true; //es invulnerable
                        Invoke("HacerVulnerable", tiempoInvulnerable); //en x tiempo, volverá a ser vulnerable
                    }
                }
                // probar lerp Color.Lerp(gameObject.GetComponent<MeshRenderer>().material.color.a, 0.3f, timeToFade * Time.deltaTime);K
            }
        }
    }

    public void HacerVulnerable()
    {
        invulnerable = false; //pasa a ser vulnerable
    }

    public void HacerInvulnerable()
    {
        invulnerable = true; //pasa a ser invulnerable
    }
}
