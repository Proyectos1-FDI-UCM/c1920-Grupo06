using UnityEngine;

//Comportamiento de la plataforma Agrietada

public class PlataformaAgrietada : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision) //al entrar en el "trigger" secundario (mayor que la plataforma)
    {
        Estados estadoAct = collision.gameObject.GetComponent<Estados>(); //guardamos el estado

        //si ha entrado el jugador, y está usando el dash o el gancho
        if (estadoAct != null && (estadoAct.Estado() == estado.MovimientoGancho || estadoAct.Estado() == estado.Dash))
        {
            //recargamos salto/dash/gancho
            collision.gameObject.GetComponent<Jugador>().RecargaSuelo();
            //destruimos la plataforma
            transform.parent.gameObject.SetActive(false);
        }
    }
}
