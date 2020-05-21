using UnityEngine;

//Comportamiento de la plataforma Agrietada

public class PlataformaAgrietada : MonoBehaviour
{
    BoxCollider2D col = null;
    private void Start()
    {
        col = transform.parent.GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collision) //al entrar en el "trigger" secundario (mayor que la plataforma)
    {
        Estados estadoAct = collision.gameObject.GetComponent<Estados>(); //guardamos el estado

        col.enabled = true;

        //si ha entrado el jugador, y está usando el dash o el gancho
        if (estadoAct != null && (estadoAct.Estado() == estado.MovimientoGancho || estadoAct.Estado() == estado.Dash))
        {
            //destruimos la plataforma
            transform.parent.gameObject.SetActive(false);
        }
    }


    void OnTriggerStay2D(Collider2D collision)
    {
        Estados estadoJugador = collision.GetComponent<Estados>();
        col.enabled = true;

        if (estadoJugador != null && estadoJugador.Estado() == estado.Dash)
        {
            transform.parent.gameObject.SetActive(false);
        }
    }
}
