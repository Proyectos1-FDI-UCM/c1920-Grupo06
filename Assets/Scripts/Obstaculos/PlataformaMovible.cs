using UnityEngine;

//Comportamiento de la plataforma movible

public class PlataformaMovible : MonoBehaviour
{
    [Header("Velocidad desplazamiento: ")]
    [SerializeField] Vector2 initialSpeed = Vector2.zero; //velocidad inicial de la entidad (establece dirección)
    [SerializeField] GameObject puntoA = null, puntoB = null; //limites inferior (izquierda, abajo) y superior (derecha, arriba)
    [SerializeField] bool horizontal; //booleano que indica si la plataforma se mueve de manera horizontal o vertical
    Rigidbody2D rb; //RigidBody de la identidad
    Transform padre;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>(); //obtenemos el RB de la entidad
        //si es horizontal, congelamos ejes Y y Z
        if (horizontal) rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        //si es vertical, congelamos ejes X y Z
        else rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
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

    //void OnTriggerEnter2D(Collider2D other) 
    //{
    //    Suelo pies = other.gameObject.GetComponent<Suelo>(); //comprobamos si ha detectado a los pies

    //    if (pies != null) //si es el jugador
    //    {
    //        padre = other.transform.parent.parent; //guardamos su padre
    //        other.transform.parent.parent = gameObject.transform; //cambiamos su padre a la plataforma movible
    //    }
    //}

    //void OnTriggerExit2D(Collider2D other)
    //{
    //    Suelo pies = other.gameObject.GetComponent<Suelo>(); //comprobamos si ha detectado a los pies

    //    if (pies != null) //si es el jugador
    //    {
    //        other.transform.parent.parent = padre; //hacemos que vualva a ser hijo de su padre anterior
    //    }
    //}
}
