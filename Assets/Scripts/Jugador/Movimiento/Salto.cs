using UnityEngine;

//Control del salto que hace el jugador

public class Salto : MonoBehaviour
{
    [SerializeField] [Range(5, 10)] float fuerza_salto = 2; //Fuerza del salto
    Estadisticas estadisticas = null; //Referencia de las estadísticas
    Rigidbody2D rb;
    Suelo suelo;
    Estados estados;
    estado estadoOri;
    bool salto_disponible = true; //booleano que controla si se puede saltar o no

    void Start()
    {
        //inicializamos las referencias
        suelo = GetComponentInChildren<Suelo>();
        rb = GetComponent<Rigidbody2D>();
        estadisticas = GetComponent<Jugador>().estadisticas;
        estados = GetComponent<Estados>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && salto_disponible && suelo.EnSuelo()) //si se pulsa la tecla de salto cuando el salto este disponible
        {
            Salta();
        }
    }

    public void RecargaSalto() //método para recargar los saltos al llegar a una superficie
    {
        salto_disponible = true;
    }

    //métodos utilizados para el PowerUp "SaltoPotenciado"
    public float GetFuerzaSalto() //método que devuelve la fuerza del salto
    {
        return fuerza_salto;
    }

    public void PowerUpSalto(float nueva_fuerza) //método que actualiza la fuerza del salto
    {
        fuerza_salto = nueva_fuerza;
    }

    public void Salta()
    {
        estadisticas.Salto(); //Sumamos un salto a las estadísticas

        rb.gravityScale = 1.5f; //reestablecemos la gravedad
        rb.AddForce(Vector2.up * fuerza_salto, ForceMode2D.Impulse); //se aplica la fuerza del salto
        salto_disponible = false; //se cambia la disponibilidad del salto a false
    }

    public void CambiaFuerzaSalto(float fuerza)
    {
        fuerza_salto = fuerza;
    }

    public void Knockback(Vector3 posObstaculo)
    {
        estadoOri = estados.Estado();
        estados.CambioEstado(estado.Knockback);
        float dirx = Metodos.Vector3toVector2(posObstaculo - transform.position).normalized.x;
        Vector2 dir = new Vector2(-dirx * 2, Vector2.up.y / 1.25f);
        rb.AddForce(dir * fuerza_salto, ForceMode2D.Impulse); //se aplica la fuerza del salto
        salto_disponible = false; //se cambia la disponibilidad del salto a false
        Invoke("ReiniciaEstado", 0.3f);
    }

    void ReiniciaEstado()
    {
        estados.CambioEstado(estadoOri);
    }
}
