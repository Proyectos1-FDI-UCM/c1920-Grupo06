using UnityEngine;

public class Suelo : MonoBehaviour
{
    //Este script lo tienen los pies del jugador para comprobar que el jugador colisiona con una plataforma

    Jugador jugador;

    bool enSuelo = false;
    void Start()
    {
        jugador = gameObject.GetComponentInParent<Jugador>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        enSuelo = true;

        if (collision.gameObject.layer == 8) //Layer 8 es la capa de las plataformas y del escenario
        {
            jugador.RecargaSuelo(); //Llama a recarga suelo del jugador
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        enSuelo = false;
    }
    public bool EnSuelo()
    {
        return enSuelo;
    }
}
