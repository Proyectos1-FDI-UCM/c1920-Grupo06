using UnityEngine;

//Comportamiento de la plataforma Jumpthrough

public class PlataformaJumpthrough : MonoBehaviour
{
    Collider2D colTrigger; //referencia al collider de la plataforma

    void Start()
    {
        //guardamos el collider
        colTrigger = GetComponent<Collider2D>();
    }

    private void OnTriggerExit2D(Collider2D collision) //cuando el jugador atraviese la plataforma
    {
        Bounds borde = colTrigger.bounds; //guardamos el borde del trigger

        //si el jugador atraviesa la plataforma por encima
        if (collision.gameObject.transform.position.y > transform.position.y + borde.extents.y)
        {
            colTrigger.isTrigger = false; //hacemos que la plataforma deje de ser un "trigger"
        }
    }
}
