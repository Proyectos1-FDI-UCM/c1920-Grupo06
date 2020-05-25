using UnityEngine;

//Comportamiento de la plataforma Inestable

public class PlataformaInestable : MonoBehaviour
{
    [SerializeField] float velBajada = 5f, distancia = 10f; //velocidad de bajada, distancia de bajada
    Vector2 origen, bordes; //posición origen de la plataforma, bordes de la plataforma
    float velY = 0; //elemento 'y' del vector2 de bajada
    float gravedadOriginal;

    void Start()
    {
        //guardamos su origen, y los bordes
        origen = transform.position;
        bordes = GetComponent<Collider2D>().bounds.extents;
    }

    void Update()
    {
        //si la posición de la plataforma supera el origen
        if (transform.position.y >= origen.y) 
        {
            //paramos la velocidad
            velY = 0;
            transform.position = origen; //colocamos la plataforma en el origen
        }
        //si la posición de la plataforma es inferior a la distancia máxima
        if (transform.position.y + velY * Time.deltaTime < origen.y - distancia)
        {
            //paramos la velocidad
            velY = 0;
            transform.position = new Vector2(origen.x, origen.y - distancia); //colocamos la plataforma en la máxima distancia
        }

        //movemos la plataforma con respecto a los cambios en "velY"
        transform.Translate(new Vector2(0, velY) * Time.deltaTime);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Jugador>() != null) 
        {
            Vector2 pos = collision.transform.position;
            //si el jugador está sobrela plataforma
            if (pos.x >= transform.position.x - bordes.x / 1.2 && pos.x <= transform.position.x + bordes.x / 1.2 && pos.y > transform.position.y)
            {
                //lo hacemos hijo
                collision.transform.parent = transform;
                velY = velBajada; //establecemos velY como -velBajada
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        //cuando el jugador salga, dejamos que deje de ser padre, y hacemos que vaya subiendo poco a poco
        collision.transform.parent = null;
        velY = -velBajada/2;
    }
}
