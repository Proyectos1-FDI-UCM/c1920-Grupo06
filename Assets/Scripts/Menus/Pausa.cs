using UnityEngine;

//Control del menú de pausa por parte del jugador

public class Pausa : MonoBehaviour
{
    [SerializeField] Suelo suelo;
    Estados estados;
    bool pausa;
    Controles controles;

    private void Awake()
    {
        controles = new Controles();
        controles.Jugador.Pausa.performed += ctx => Pausar();
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
        //guardamos los estados del jugador
        estados = gameObject.GetComponent<Estados>();
    }

    void Pausar()
    {
        //si el jugador se encuentra en el suelo, y presiona el botón de pausa
        if (Time.timeScale != 0 && estados.Estado() == estado.Defecto && suelo.EnSuelo())
        {
            //mostramos el menú de pausa
            GameManager.instance.Pausa();
            estados.CambioEstado(estado.Inactivo); //pasamos al estado inactivo
        }
        else if(Time.timeScale == 0) //si está en pausa
        {
            estados.CambioEstado(estado.Defecto); //volvemos al estado por defecto
            Input.ResetInputAxes(); //reseteamos los valores de input
            GameManager.instance.QuitarPausa(); //quitamos el menú de pausa
        }
    }
}
