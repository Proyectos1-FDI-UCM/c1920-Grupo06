using UnityEngine;

//Control del menú de pausa por parte del jugador

public class Pausa : MonoBehaviour
{
    Estados estado;
    public Suelo suelo;
    bool pausa;

    void Start()
    {
        //guardamos los estados del jugador
        estado = gameObject.GetComponent<Estados>();
    }

    void Update()
    {
        //si el jugador se encuentra en el suelo, y presiona el botón de pausa
        if (Time.timeScale != 0 && Input.GetButtonDown("Cancel") && estado.Estado() == global::estado.Defecto && suelo.EnSuelo())
        {
            //mostramos el menú de pausa
            GameManager.instance.Pausa();
            estado.CambioEstado(global::estado.Inactivo); //pasamos al estado inactivo
        }
        else if(Time.timeScale == 0 && Input.GetButtonDown("Cancel")) //si está en pausa
        {
            estado.CambioEstado(global::estado.Defecto); //volvemos al estado por defecto
            Input.ResetInputAxes(); //reseteamos los valores de input
            GameManager.instance.QuitarPausa(); //quitamos el menú de pausa
        }
    }
}
