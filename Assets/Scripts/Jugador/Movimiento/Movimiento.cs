using UnityEngine;

public class Movimiento : MonoBehaviour
{
    //Script que permite moverte de forma horizontal

    Rigidbody2D rb;
    [SerializeField] [Range(15, 25)] float velocidad_movimiento = 20; //velocidad del desplazamiento
    [SerializeField] [Range(-30, 0)] float velocidad_caida_maxima = -20;

    DeslizamientoPared deslizamiento;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        deslizamiento = GetComponent<DeslizamientoPared>();
    }
    void Update() 
    {
        float input = Input.GetAxis("Horizontal");

        if (deslizamiento.Deslizando() == "derecha" && input > 0)
            input = 0;
        else if (deslizamiento.Deslizando() == "izquierda" && input < 0)
            input = 0;

        rb.velocity = new Vector2(input * velocidad_movimiento, rb.velocity.y);

        if(rb.velocity.y < velocidad_caida_maxima)
        {
            Vector2 velocidad = rb.velocity; velocidad.y = velocidad_caida_maxima;
            rb.velocity = velocidad;
        }
    }
}
