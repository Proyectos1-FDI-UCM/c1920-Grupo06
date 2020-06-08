using UnityEngine;

//Script para corregir animaciones al entrar en "triggers" que no deberían efectuar animación

public class AnulaAnimacion : MonoBehaviour
{
    AnimacionesJugador animacionesJugador = null;
    Estados estado = null;

    void OnTriggerEnter2D(Collider2D other)
    {
        animacionesJugador = other.gameObject.GetComponent<AnimacionesJugador>();
        estado = other.gameObject.GetComponent<Estados>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (animacionesJugador != null && estado != null)
        {
            animacionesJugador.AnulaAnim();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (animacionesJugador != null && estado != null)
        {
            animacionesJugador.StopAnulaAnim();
        }
    }
}
