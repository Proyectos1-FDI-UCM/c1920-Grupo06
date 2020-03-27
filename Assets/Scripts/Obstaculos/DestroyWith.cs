using UnityEngine;

public class DestroyWith : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Estados estadoAct = collision.gameObject.GetComponent<Estados>(); //QUE COÑO HACÍA ESTE

        if (estadoAct != null && (estadoAct.Estado() == estado.MovimientoGancho || estadoAct.Estado() == estado.Dash))
        {
            //Provisional
            collision.gameObject.GetComponent<Jugador>().RecargaSuelo();
            //fin del provisional
            transform.parent.gameObject.SetActive(false);
        }
    }
}
