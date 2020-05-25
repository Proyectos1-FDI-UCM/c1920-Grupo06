using UnityEngine;

//Comportamiento de la plataforma Inestable

public class PlataformaInestable : MonoBehaviour
{
    [SerializeField] Transform puntoB = null;
    [SerializeField] float velBajada = 5f; //velocidad de bajada, distancia de bajada
    Vector2 origen, bordes; //posición origen de la plataforma, bordes de la plataforma
    bool contacto = false;
    Animator animation = null;

    void Start()
    {
        //guardamos su origen, y los bordes
        origen = transform.position;
        bordes = GetComponent<Collider2D>().bounds.extents;
        animation = GetComponent<Animator>();
        animation.enabled = false;
    }

    void Update()
    {
        //si se ha salido de los límites superiores (arriba)
        if (transform.position.y >= puntoB.transform.position.y)
        {
            transform.position = puntoB.position;
        }
        //si se ha salido de los límites inferiores (abajo)
        else if (transform.position.y <= origen.y)
        {
            transform.position = origen;
        }

        //movemos la plataforma con respecto a los cambios en "velY"
        if (contacto) transform.position = Vector3.MoveTowards(transform.position, puntoB.position, velBajada * Time.deltaTime);
        else transform.position = Vector3.MoveTowards(transform.position, origen, velBajada/2 * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Jugador jugador = collision.gameObject.GetComponent<Jugador>();

        if (jugador != null)
        {
            Vector2 pos = collision.transform.position;
            //si el jugador está sobrela plataforma
            if (pos.x >= transform.position.x - bordes.x / 2 && pos.x <= transform.position.x + bordes.x / 2 && pos.y > transform.position.y)
            {
                //lo hacemos hijo
                collision.transform.parent = transform;
                animation.enabled = true;
                contacto = true;
            }
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        Jugador jugador = collision.gameObject.GetComponent<Jugador>();

        if (jugador != null) 
        {
            Vector2 pos = collision.transform.position;
            //si el jugador está sobrela plataforma
            if (pos.x >= transform.position.x - bordes.x / 2 && pos.x <= transform.position.x + bordes.x / 2 && pos.y > transform.position.y)
            {
                //lo hacemos hijo
                collision.transform.parent = transform;
                contacto = true;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        //cuando el jugador salga, dejamos que deje de ser padre, y hacemos que vaya bajando poco a poco
        collision.transform.parent = null;
        Invoke("CambiarContacto", 0.1f);
    }

    void CambiarContacto()
    {
        contacto = false;
    }
}
