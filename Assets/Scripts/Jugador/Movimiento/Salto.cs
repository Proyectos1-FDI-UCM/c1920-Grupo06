using UnityEngine;

//Control del salto que hace el jugador

public class Salto : MonoBehaviour
{
    [SerializeField] [Range(5, 10)] float fuerza_salto = 2; //Fuerza del salto
    Estadisticas estadisticas = null; //Referencia de las estadísticas
    Rigidbody2D rb;
    Suelo suelo;
    CrearDash dash;
    Estados estados;
    estado estadoOri;
    bool salto_disponible = true; //booleano que controla si se puede saltar o no
    AudioSource aud;
    AudioSource[] audAux;

    void Start()
    {
        //inicializamos las referencias
        suelo = GetComponentInChildren<Suelo>();
        rb = GetComponent<Rigidbody2D>();
        estadisticas = GetComponent<Jugador>().estadisticas;
        estados = GetComponent<Estados>();

        audAux = GetComponents<AudioSource>();
        aud = audAux[EncuentraAudioSource(audAux, "Salto")];
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

    public void DesactivaSalto()
    {
        salto_disponible = false;
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
        aud.Play();
    }

    public void CambiaFuerzaSalto(float fuerza)
    {
        fuerza_salto = fuerza;
    }

    private int EncuentraAudioSource(AudioSource[] audAux, string name)
    {
        int i = 0;
        bool enc = false;
        while (i < audAux.Length && !enc)
        {
            if (audAux[i].clip.name == name) enc = true;
            else i++;
        }
        return i;
    }
}
