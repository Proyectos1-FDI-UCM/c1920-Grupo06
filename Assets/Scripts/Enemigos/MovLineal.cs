using UnityEngine;

//Comportamiento de movimiento de "EnemigoBásico" y "EnemigoVolador"

public class MovLineal : MonoBehaviour
{
    [Header("Velocidad desplazamiento: ")]
    [SerializeField] Vector2 initialSpeed = Vector2.zero; //velocidad inicial de la entidad (establece dirección)
    [SerializeField] GameObject puntoA = null, puntoB = null; //limites inferior (izquierda, abajo) y superior (derecha, arriba)
    [SerializeField] bool horizontal = false; //booleano que indica si la plataforma se mueve de manera horizontal o vertical
    Rigidbody2D rb; //RigidBody de la identidad

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>(); //obtenemos el RB de la entidad
    }

    void OnEnable() //cuando se active (reaparición)
    {
        rb.velocity = initialSpeed; //establecemos su velocidad y dirección
        Rotacion();
    }

    void Update()
    {
        Limites(); //comprobamos si se ha salido de los límites
    }

    void Limites()
    {
        if (horizontal)
        {
            //si se ha salido de los límites superiores (derecha)
            if (transform.position.x >= puntoB.transform.position.x)
            {
                rb.velocity = -initialSpeed;
                Rotacion();
            }
            //si se ha salido de los límites inferiores (izquierda)
            else if (transform.position.x < puntoA.transform.position.x)
            {
                rb.velocity = initialSpeed;
                Rotacion();
            }
        }
        else
        {
            //si se ha salido de los límites superiores (arriba)
            if (transform.position.x > puntoB.transform.position.x || transform.position.y > puntoB.transform.position.y)
            {
                rb.velocity = -initialSpeed;
            }
            //si se ha salido de los límites inferiores (abajo)
            else if (transform.position.x < puntoA.transform.position.x || transform.position.y < puntoA.transform.position.y)
            {
                rb.velocity = initialSpeed;
            }
        }
    }

    void Rotacion() //metodo para elegir la rotacion acorde al movimiento
    {
        if (rb.velocity.x > 0) transform.eulerAngles = new Vector2(transform.rotation.x, 180f);
        else transform.eulerAngles = new Vector2(transform.rotation.x, 0f);
    }
}
