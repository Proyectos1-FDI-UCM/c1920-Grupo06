using UnityEngine;

//Comportamiento del deslizamiento del jugador en las paredes

public class DeslizamientoPared : MonoBehaviour
{
    [SerializeField] float distancia_Recorrida_Raycast = 0.5f;
    [SerializeField] float velocidad_Deslizamiento = -0.5f;
    BoxCollider2D box;
    const float delta = 0.1f;
    Rigidbody2D rb;
    string deslizando = "";
    int layers;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        layers = LayerMask.GetMask("Escenario");
    }

    private void FixedUpdate()
    {
        RaycastHit2D rayCastDerechaArriba, rayCastDerechaAbajo, rayCastIzquierdaArriba, rayCastIzquierdaAbajo;

        Vector2 derecha = transform.position;
        derecha.x += (box.size.x / 4f) + delta; //4 porque al parecer,el nuevo jugador escala sus tamaños a la mitad
        derecha.y += (box.size.y / 4f);


        Vector2 izquierda = transform.position;
        izquierda.x -= (box.size.x / 4f) + delta;
        izquierda.y += (box.size.y / 4f);

        rayCastDerechaArriba = Physics2D.Raycast(derecha, Vector2.right, distancia_Recorrida_Raycast, layers);
        rayCastIzquierdaArriba = Physics2D.Raycast(izquierda, Vector2.left, distancia_Recorrida_Raycast, layers);


        Debug.DrawLine(derecha, derecha + new Vector2(distancia_Recorrida_Raycast, 0));
        Debug.DrawLine(izquierda, izquierda - new Vector2(distancia_Recorrida_Raycast, 0));

        derecha.y -= (box.size.y / 2f);
        izquierda.y -= (box.size.y / 2f);
        rayCastDerechaAbajo = Physics2D.Raycast(derecha, Vector2.right, distancia_Recorrida_Raycast, layers);
        rayCastIzquierdaAbajo = Physics2D.Raycast(izquierda, Vector2.left, distancia_Recorrida_Raycast, layers);

        Debug.DrawLine(derecha, derecha + new Vector2(distancia_Recorrida_Raycast, 0));
        Debug.DrawLine(izquierda, izquierda - new Vector2(distancia_Recorrida_Raycast, 0));


        if ((rayCastIzquierdaArriba || rayCastIzquierdaAbajo) && rb.velocity.y <= 0)
        {
            LayerMask colision;
            if (rayCastIzquierdaAbajo)
                colision = rayCastIzquierdaAbajo.collider.gameObject.layer;
            else
                colision = rayCastIzquierdaArriba.collider.gameObject.layer;

            if (colision != 14)
            {
                rb.velocity = new Vector2(rb.velocity.x, velocidad_Deslizamiento);
                deslizando = "izquierda";
            }
            else deslizando = "";
        }
        else if ((rayCastDerechaArriba || rayCastDerechaAbajo) && rb.velocity.y <= 0)
        {
            LayerMask colision;
            if (rayCastDerechaAbajo)
                colision = rayCastDerechaAbajo.collider.gameObject.layer;
            else
                colision = rayCastDerechaArriba.collider.gameObject.layer;

            if (colision != 14)
            {
                rb.velocity = new Vector2(rb.velocity.x, velocidad_Deslizamiento);
                deslizando = "derecha";
            }
        }
        else deslizando = "";
    }

    public string Deslizando() //metodo que devuelve si el jugador se está deslizando o no
    {
        return deslizando;
    }
}
