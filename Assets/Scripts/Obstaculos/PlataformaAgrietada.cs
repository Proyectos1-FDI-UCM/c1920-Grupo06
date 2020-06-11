using UnityEngine;

//Comportamiento de la plataforma Agrietada

public class PlataformaAgrietada : MonoBehaviour
{

   // bool ignora = false;

    void OnTriggerEnter2D(Collider2D collision) //al entrar en el "trigger" secundario (mayor que la plataforma)
    {
        //ignora = false;
        Estados estadoAct = collision.gameObject.GetComponent<Estados>();
        //Dash dash = collision.gameObject.GetComponent<Dash>();

        if (estadoAct != null && (estadoAct.Estado() == estado.MovimientoGancho || estadoAct.Estado() == estado.Dash))
            transform.parent.gameObject.SetActive(false);
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        Estados estadoAct = collision.gameObject.GetComponent<Estados>();
        Dash dash = collision.gameObject.GetComponent<Dash>();

        if (estadoAct != null && estadoAct.Estado() == estado.Dash)
        {
            transform.parent.gameObject.SetActive(false);
            dash.ReDashea();
        }
    }
}
