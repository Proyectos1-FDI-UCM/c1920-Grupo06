using UnityEngine;

//Control de las animaciones del jugador

public class AnimacionesJugador : MonoBehaviour
{
    [SerializeField] float delta = 0.05f;
    Animator animador;
    Rigidbody2D rb;
    Suelo suelo;
    Estados estadoJugador;
    bool enSuelo = false, enSueloAux = false;
    int velx = 0, velxaux = 0;

    void Start()
    {
        //inicializamos los componentes
        animador = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        suelo = GetComponentInChildren<Suelo>();
        estadoJugador = GetComponent<Estados>();
    }

    void Update()
    {
        //comprobamos si está en el suelo
        enSuelo = suelo.EnSuelo();

        if (enSuelo != enSueloAux) //si no lo estuviera
        {
            //cambiamos su animación con respecto al estado actual del jugador
            CambioAnimacion(estadoJugador.Estado());
            enSueloAux = enSuelo; //establecemos que no se encuentra en el suelo
        }
        if (enSuelo) //si estuviera en el suelo
        {
            //guardamos su velocidad en el eje 'x'
            float velocidad = rb.velocity.x;

            if (velocidad < -delta) velx = 0; //si la velocidad negativa, la animación es "MovimientoInvertido"
            else if (velocidad > delta) velx = 2; //si es positiva, la animación es "Movimiento"
            else velx = 1; //en caso contrario, es "Iddle"

            //si la dirección es distinta de en la que ya se encontraba
            if (velx != velxaux)
            {
                //cambiamos la animación con respecto al estado del jugador
                CambioAnimacion(estadoJugador.Estado());
                velxaux = velx; //actualizamos la dirección
            }
        }
    }

    public void CambioAnimacion(estado estadoActual) //método para cambiar la animación
    {
        switch (estadoActual)
        {
            case estado.Defecto: //de estar sobre una plataforma
                float velocidad = rb.velocity.x;

                //establecemos la animación con respecto a la velocidad
                if (!enSuelo)
                    animador.Play("Caida");
                else if (velocidad < -delta)
                    animador.Play("MovimientoInvertido");
                else if (velocidad > delta)
                    animador.Play("Movimiento");
                else animador.Play("Iddle");
                break;
            case estado.Dash:
                animador.Play("Dash");
                break;
            default: //en caso contrario, ponemos la animación "Caída" por defecto
                animador.Play("Caida");
                break;
        }
    }
}
