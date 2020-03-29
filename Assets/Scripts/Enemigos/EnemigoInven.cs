using UnityEngine;

public class EnemigoInven : MonoBehaviour
{
    [SerializeField] Transform player = null;
    [SerializeField] float maxTime = 0f, speed = 0f;
    int intentos = 3;
    Vector3 tr = Vector3.zero;
    Rigidbody2D rb = null;
    string estado;
    bool soyvisible = true; //creo que hay otra forma mejor de hacerlo que dijisteis pero lo he apañado rapido para que no me moleste 
    //probando la puntuacion

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
        soyvisible = true;
    }
    private void OnBecameInvisible()
    {
        estado = "estoyFuera";
        soyvisible = false;
    }
    private void Update()
    {
        if (estado == "estadoMovimiento" && soyvisible)
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
                    gameObject.SetActive(false);
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
