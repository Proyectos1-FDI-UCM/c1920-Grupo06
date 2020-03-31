using UnityEngine;

//Comportamiento de la plataforma Tiempo

public class PlataformaTiempo : MonoBehaviour
{
    [SerializeField] float TiempoDesaparicion = 0; //tiempo de desaparición

    void OnCollisionEnter2D(Collision2D collision) 
    {
        //guardamos los "bounds" y el componente de la colisión 
        Bounds borde = GetComponent<BoxCollider2D>().bounds;
        Estados estados = collision.gameObject.GetComponent<Estados>();

        //si la colisión se produce sobre la plataforma y es el jugador
        if (estados != null && estados.gameObject.transform.position.y > transform.position.y + borde.extents.y)
        {
            Invoke("Desactivar", TiempoDesaparicion); //hacemos que desaparezca tras cierto tiempo
        }
    }
    void Desactivar() //método para que desaparezca
    {
        gameObject.SetActive(false);
    }
}
