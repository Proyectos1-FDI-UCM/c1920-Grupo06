using UnityEngine;

//COmportamiento de "EnemigoInvencible"

public class EnemigoInven : MonoBehaviour
{
    [SerializeField] Transform player = null; //referncia al transform del jugador
    [SerializeField] float maxTime = 0f, speed = 0f; //tiempo de búsqueda, velocidad de movimiento
    int intentos = 3; //numero de intentos del enemigo para intentar alcanzar al jugador
    Vector3 posJugador = Vector3.zero; //posición del jugador
    Rigidbody2D rb = null;
    string estado; //estado del enemigo invencible
    bool visible = true; //creo que hay otra forma mejor de hacerlo que dijisteis pero lo he apañado rapido para que no me moleste 
    //probando la puntuacion

    void Awake()
    {
        //guardamos su RB
        rb = GetComponent<Rigidbody2D>();
        estado = "estoyFuera"; //establecemos su estado como que se encuentra fuera
    }

    void OnEnable() //al activarse (reaparición)
    {
        //reestablecemos el número de intentos
        intentos = 3;
    }

    void OnBecameVisible() //cuando es visible
    {
        //cambiamos su estado a movimiento en el tiempo establecido
        Invoke("Estado", maxTime);
        visible = true; //establecemos que se encuentra en la pantalla
    }

    void Update()
    {
        if (estado == "estadoMovimiento" && visible) //si está en estado movimiento
        {
            Vector3 distancia = posJugador - transform.position; //comprobamos su distancia con respecto al punto a alcanzar

            if (distancia.magnitude > 0.1f) //si aun no ha alcanzado dicho punto
            {
                //hacemos que se mueva al destino
                rb.velocity = distancia.normalized * speed;
            }
            else //en caso de haber alcanzado el destino
            {
                rb.velocity = Vector2.zero; //el enemigo para
                intentos--; //resatmos 1 a sus intentos
                estado = "estadoPensando"; //Establecemos su estado a "estoyPensando"
                Invoke("Estado", maxTime); //cambiamos su estado a "estadoMovimiento" tras un tiempo determinado
                if (intentos == 0) //si ha gastado todos sus intentos
                {
                    gameObject.SetActive(false); //desaparece
                }
            }
        }
    }

    void OnBecameInvisible() //cuando deja de ser visible
    {
        //cambiamos su estado correspondientemente
        estado = "estoyFuera";
        visible = false;
    }

    void Estado() //método que se encarga de establecer el estado a "estadoMovimiento"
    {
        estado = "estadoMovimiento";
        posJugador = player.position; //establece la nueva posición del jugador detectada por el enemigo
    }
}
