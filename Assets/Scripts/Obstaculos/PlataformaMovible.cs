using UnityEngine;

//Comportamiento de la plataforma movible

public class PlataformaMovible : MonoBehaviour
{
    [Header("Velocidad desplazamiento: ")]
    [SerializeField] Vector2 initialSpeed = Vector2.zero; //velocidad inicial de la entidad (establece dirección)
    [SerializeField] GameObject puntoA = null, puntoB = null; //limites inferior (izquierda, abajo) y superior (derecha, arriba)
    [SerializeField] bool horizontal = false; //booleano que indica si la plataforma se mueve de manera horizontal o vertical
    [SerializeField] Transform padre;
    [SerializeField] Estados estados;
    GameObject jugador;
    Rigidbody2D rbJugador;
    Rigidbody2D rb;


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
        if (horizontal)
        {
            //si se ha salido de los límites superiores (derecha)
            if (transform.position.x > puntoB.transform.position.x)
            {
                rb.velocity = -initialSpeed;
            }
            //si se ha salido de los límites inferiores (izquierda)
            else if (transform.position.x < puntoA.transform.position.x)
            {
                rb.velocity = initialSpeed;
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

    //En caso de que el jugador esté encima de la plataforma
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (horizontal) //Si es la horizontal
        {
            //Se comprueba si verdaderamente se ha subido el jugador
            Suelo pies = collision.gameObject.GetComponent<Suelo>();
            if (pies != null)
            {
                jugador = collision.gameObject.transform.parent.gameObject;
                estados = jugador.GetComponent<Estados>();
                rbJugador = jugador.GetComponent<Rigidbody2D>();
            }
        }
    }

    //En caso de que el jugador siga encima de la plataforma
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (horizontal) //Si es la horizontal
        {
            //Mientras el jugador no esté en medio de otra acción
            if (!Input.anyKey && estados.Estado() == estado.Defecto && rbJugador.velocity.y <= 0)
            {
                //Se hace hijo de la plataforma
                rbJugador.isKinematic = true;
                jugador.transform.parent = transform;
            }
            else
            {
                //Deja de ser hijo de la plataforma
                rbJugador.isKinematic = false;
                jugador.transform.parent = padre;
            }
        }
    }
}

