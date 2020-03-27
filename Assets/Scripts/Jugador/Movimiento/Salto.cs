using UnityEngine;

public class Salto : MonoBehaviour
{
    //Script que controla el salto que hace el jugador
    [SerializeField] [Range(5,10)] float fuerza_salto = 2; //Fuerza con la que se salta
    Rigidbody2D rb;
    Suelo suelo;
    bool salto_disponible = true; //Dice si se puede saltar o no, como no hay doble salto es un booleano
    private void Start()
    {
        suelo = GetComponentInChildren<Suelo>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && salto_disponible && suelo.EnSuelo()) //Si se pulsa la tecla de salto y se puede saltar se ejecuta
        {
            rb.AddForce(Vector2.up * fuerza_salto, ForceMode2D.Impulse); //Se añade la fuerza
            salto_disponible = false; //Se cambia la disponibilidad a false
        }
    }
    public void RecargaSalto() //El jugador llama a este método cuando "Suelo" se activa, es decir se toca una plataforma
    {
        salto_disponible = true;
    }

    //PowerUP salto agrandado
    public float GetFuerzaSalto() //Devuelve el valor del salto
    {
        return fuerza_salto;
    }

    public void PowerUpSalto(float nueva_fuerza) //Cambia la fuerza del salto
    {
        fuerza_salto = nueva_fuerza;
    }
}
