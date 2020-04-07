using UnityEngine;

//Comportamiento de movimiento de "EnemigoBásico", "EnemigoVolador" y "PlataformaMovible"

public class MovLineal : MonoBehaviour
{
    [Header("Velocidad desplazamiento: ")]
    [SerializeField] Vector2 initialSpeed = Vector2.zero; //velocidad inicial de la entidad (establece dirección)
    [SerializeField] GameObject puntoA, puntoB; //limites inferior (izquierda, abajo) y superior (derecha, arriba)
    Rigidbody2D rb; //RigidBody de la identidad

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>(); //obtenemos el RB de la entidad
    }

    void OnEnable() //cuando se active (reaparición)
    {
        rb.velocity = initialSpeed; //establecemos su velocidad y dirección
    }

    void Update()
    {
        Limites(); //comprobamos si se ha salido de los límites
    }

    void Limites()
    {
        //si se ha salido de los límites superiores (derecha/arriba)
        if (transform.position.x > puntoB.transform.position.x || transform.position.y > puntoB.transform.position.y)
        {
            rb.velocity = -initialSpeed;
        }
        //si se ha salido de los límites inferiores (izquierda, abajo)
        else if (transform.position.x < puntoA.transform.position.x || transform.position.y < puntoA.transform.position.y)
        {
            rb.velocity = initialSpeed;
        }
    }
}
