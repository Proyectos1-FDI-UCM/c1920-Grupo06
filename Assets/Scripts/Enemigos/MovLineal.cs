using UnityEngine;

//Comportamiento de movimiento de "EnemigoBásico", "EnemigoVolador" y "PlataformaMovible"

public class MovLineal : MonoBehaviour
{
    [Header("Velocidad desplazamiento: ")]
    [SerializeField] Vector2 initialSpeed = Vector2.zero; //velocidad inicial de la entidad (establece dirección)
    Rigidbody2D rb; //RigidBody de la identidad

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>(); //obtenemos el RB de la entidad
    }

    void OnEnable() //cuando se active (reaparición)
    {
        rb.velocity = initialSpeed; //establecemos su velocidad y dirección
    }

    void OnTriggerEnter2D(Collider2D other) //cada vez que entre en un 'trigger'
    {
        Estados jugador = other.gameObject.GetComponent<Estados>(); //comprobamos si ha entrado en el jugador
        Suelo pies = other.gameObject.GetComponent<Suelo>(); //comprobamos si ha detectdo a los pies

        if (jugador == null && pies == null) //si no es el jugador
        {
            rb.velocity = -rb.velocity; //cambiamos la dirección de su movimiento
        }
    }
}
