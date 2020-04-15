using UnityEngine;

//Control de la activación del Dash

public class CrearDash : MonoBehaviour
{
    //número de cargas establecido por editor
    [SerializeField] int numeroMaximoCargas = 1;
    Estadisticas estadisticas = null; //Referencia de las estadísticsa
    Jugador jugador;
    Estados estadoJugador;
    int numeroCargas; //número de cargas
    Controles controles;


    private void Awake()
    {
        controles = new Controles();
        controles.Jugador.Dash.performed += ctx => Dash();
    }

    private void OnEnable()
    {
        controles.Jugador.Enable();
    }

    private void OnDisable()
    {
        controles.Jugador.Disable();
    }

    void Start()
    {
        //guardamos el numero de cargas
        numeroCargas = numeroMaximoCargas;
        //guardamos referencias al jugador y a los estados
        jugador = GetComponent<Jugador>();
        estadoJugador = GetComponent<Estados>();

        estadisticas = GetComponent<Jugador>().estadisticas;
    }

    void Dash()
    {
        //si se presiona el botón asignado para el Dash, y hay suficientes cargas
        if (numeroCargas > 0)
        {
            estadisticas.Dash(); //Sumamos un dash a las estadísticas

            if (Input.GetButtonDown("Dash")) //si presiona con el ratón
                jugador.DireccionDash(Metodos.DireccionPuntoRaton(transform.position));
            else //si presiona con el mando
                jugador.DireccionDash(Metodos.DireccionMando());
            estadoJugador.CambioEstado(estado.Dash); //cambiamos el estado a Dash

            numeroCargas--; //reducimos el número de cargas
        }
    }
    public void RecargarDash() //método para la recarga del Dash
    {
        numeroCargas = numeroMaximoCargas;
    }
}
