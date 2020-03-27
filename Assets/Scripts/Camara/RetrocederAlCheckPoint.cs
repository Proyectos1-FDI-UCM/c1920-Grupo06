using UnityEngine;

public class RetrocederAlCheckPoint : MonoBehaviour
{
    //Encargado de que la cámara vuelva al punto del checkpoint

    Vector3 checkPoint = Vector3.zero;
    [SerializeField] GameObject jugadorGameObject = null;
    [SerializeField][Range(1,15)] float fuerza_impulso_arriba = 1;
    Rigidbody2D rb;
    Estados estadosjugador = null;
    Jugador jugador = null;

    private void Awake()
    {
        enabled = false; //No está activado al principio

        estadosjugador = jugadorGameObject.GetComponent<Estados>();
        jugador = jugadorGameObject.GetComponent<Jugador>();
        
    }

    
    private void OnEnable()
    {
        checkPoint = GameManager.instance.CheckPoint();
        rb = gameObject.AddComponent<Rigidbody2D>();
        rb.AddForce(Vector3.up * fuerza_impulso_arriba, ForceMode2D.Impulse);
        rb.gravityScale = 4;
    }

    private void Update()
    {
        if (transform.position.y < checkPoint.y)
        {
            Destroy(rb);
            estadosjugador.CambioEstado(estado.Defecto);
            jugador.RecargaSuelo();
            enabled = false;
        }
    }
}
