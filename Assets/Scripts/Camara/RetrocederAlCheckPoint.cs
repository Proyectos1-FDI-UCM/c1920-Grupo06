using UnityEngine;

//Control de que la cámara vuelva al checkpoint

public class RetrocederAlCheckPoint : MonoBehaviour
{
    [SerializeField] GameObject jugadorGameObject = null; //referencia al jugador
    [SerializeField] [Range(1, 15)] float fuerza_impulso_arriba = 1; //valor del impulso que dará el 
    Rigidbody2D rb;
    Estados estadosjugador = null;
    Jugador jugador = null;
    Vector3 checkPoint = Vector3.zero; //posición del checkpoint a retroceder
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        enabled = false; //lo desactivamos en caso de que estuviese activo
        //inicializamos las variables
        estadosjugador = jugadorGameObject.GetComponent<Estados>();
        jugador = jugadorGameObject.GetComponent<Jugador>();
        spriteRenderer = jugadorGameObject.GetComponent<SpriteRenderer>();

    }

    void OnEnable() //al activarse
    {
        checkPoint = GameManager.instance.CheckPoint(); //guardamos el checkpoint a retroceder
        rb = gameObject.AddComponent<Rigidbody2D>(); //le creamos un RB
        rb.AddForce(Vector3.up * fuerza_impulso_arriba, ForceMode2D.Impulse); //le ejercemos un pequeño impulso hacia arriba
        rb.gravityScale = 4; //le ponemos una gravedad, para que "caiga" al checkpoint
    }

    void Update()
    {
        if (transform.position.y < checkPoint.y) //en cuanto llegue a la posición del checkpoint
        {
            Destroy(rb); //destruimos su RB
            estadosjugador.CambioEstado(estado.Defecto); //actualizamos el estado del jugador
            jugador.RecargaSuelo(); //recargamos los usos de salto, dash y gancho
            spriteRenderer.enabled = true;  //reactivamos el sprite que fue desactivado en el gameManager al morir
            enabled = false; //desactivamos este script
        }
    }
}
