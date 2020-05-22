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

    void Start()
    {
        //guardamos el numero de cargas
        numeroCargas = numeroMaximoCargas;
        //guardamos referencias al jugador y a los estados
        jugador = GetComponent<Jugador>();
        estadoJugador = GetComponent<Estados>();

        estadisticas = GetComponent<Jugador>().estadisticas;
    }

    void Update()
    {
        //si se presiona el botón asignado para el Dash, y hay suficientes cargas
        if (Input.GetButtonDown("Dash") && numeroCargas > 0)
        {
            estadisticas.Dash(); //Sumamos un dash a las estadísticas

            jugador.DireccionDash(Metodos.DireccionPuntoRaton(transform.position));
            estadoJugador.CambioEstado(estado.Dash); //cambiamos el estado a Dash

            numeroCargas--; //reducimos el número de cargas
        }
    }
    public void RecargarDash() //método para la recarga del Dash
    {
        numeroCargas = numeroMaximoCargas;
    }
}
