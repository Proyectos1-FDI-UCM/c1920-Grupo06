using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaInestable : MonoBehaviour
{
    Vector2 origen;
    [SerializeField] float velBajada = 5;
    [SerializeField] float distancia = 10;
    float speed = 0;
    float gravedadOriginal;
    Vector2 bordes;

    void Start()
    {
        origen = transform.position;
        bordes = GetComponent<Collider2D>().bounds.extents;
    }

    private void Update()
    {
        if (transform.position.y >= origen.y)
        {
            speed = 0;
            transform.position = origen;
        }
        if (transform.position.y + speed * Time.deltaTime < origen.y - distancia)
        {
            speed = 0;
            transform.position = new Vector2(origen.x, origen.y - distancia);
        }
        transform.Translate(new Vector2(0, speed) * Time.deltaTime);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Jugador>() != null)
        {
            Vector2 pos = collision.transform.position;
            if (pos.x >= transform.position.x - bordes.x / 1.2 && pos.x <= transform.position.x + bordes.x / 1.2 && pos.y > transform.position.y)
            {
                collision.transform.parent = transform;
                speed = -velBajada;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.parent = null;
        speed = 2.4f;
    }
}
