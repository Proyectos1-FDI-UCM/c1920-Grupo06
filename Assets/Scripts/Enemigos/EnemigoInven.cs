using UnityEngine;

public class EnemigoInven : MonoBehaviour
{
    [SerializeField] Transform player = null;
    [SerializeField] float maxTime = 0f, speed = 0f;
    int intentos = 3;
    Vector3 tr = Vector3.zero;
    Rigidbody2D rb = null;
    string estado;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        estado = "estoyFuera";
    }
    private void OnEnable()
    {
        intentos = 3;
    }

    private void OnBecameVisible()
    {
        Invoke("Estado", maxTime);
    }

    private void Update()
    {
        if (estado == "estadoMovimiento")
        {
            Vector3 distancia = tr - transform.position;

            if (distancia.magnitude > 0.1f)
            {
                // Moverme hacia el destino
                rb.velocity = distancia.normalized * speed;
            } 
            else
            {
                // Ya he llegado al destino
                rb.velocity = Vector2.zero;
                intentos--;
                estado = "estadoPensando";
                Invoke("Estado", maxTime);
                if (intentos == 0)
                {
                    this.gameObject.SetActive(false);
                }
            }
        }
    }
    void Estado()
    {
        estado = "estadoMovimiento";
        tr = player.position;
    }
}
