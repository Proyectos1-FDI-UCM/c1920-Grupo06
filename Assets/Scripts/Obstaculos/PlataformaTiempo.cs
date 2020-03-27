using UnityEngine;

public class PlataformaTiempo : MonoBehaviour
{
    [SerializeField] float TiempoDesaparicion = 0;
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        Bounds borde = GetComponent<BoxCollider2D>().bounds;
        Estados aux = collision.gameObject.GetComponent<Estados>();
        if (aux != null && aux.gameObject.transform.position.y > transform.position.y + borde.extents.y)
        {
            Invoke("Desactivate", TiempoDesaparicion);
        }
    }
    void Desactivate()
    {
        gameObject.SetActive(false);
    }
}
