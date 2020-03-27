using UnityEngine;

public class CrearDash : MonoBehaviour
{
    Jugador jugador;
    Estados estadoJugador;

    [SerializeField] int numeroMaximoCargas = 1;
    int numeroCargas;
    private void Start()
    {
        numeroCargas = numeroMaximoCargas;
        jugador = GetComponent<Jugador>();
        estadoJugador = GetComponent<Estados>();
    }
    private void Update()
    {
        if ((Input.GetButtonDown("Dash") || Input.GetButtonDown("DashMando")) && numeroCargas > 0)
        {
            if (Input.GetButtonDown("Dash"))
                jugador.DireccionDash(Metodos.Direccion_Punto_Mouse(transform.position));
            else
                jugador.DireccionDash(Metodos.DireccionMando());
            estadoJugador.CambioEstado(estado.Dash);
            numeroCargas--;
        }
    }
    public void RecargarDash()
    {
        numeroCargas = numeroMaximoCargas;
    }
}
