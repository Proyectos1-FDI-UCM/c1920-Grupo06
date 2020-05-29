using UnityEngine;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
        /*He cambiado como funciona el tiempo para usar Time.time porqué leí que de esta forma era mejor
         y no era dependiente del Update o FixedUpdate 
     
        El tiempo se cuenta desde 0 hasta el tiempo máximo pero al pasarlo al UIManager se invierte para que sea
        una cuenta descendente no ascendente
         
         */

    [SerializeField] UIManager theUIManager = null; //Referencia del UI manager
    [SerializeField] float tiempoMaximoInicial = 100; //Valor inicial del tiempo al empezar el nivel
    [SerializeField] AudioSource tics = null;
    float timer; //Variable que refleja el tiempo que lleva el jugador
    float tiempoInicio; //Cuenta desde cuando empezó a contar el tiempo
    float tiempoMaximo; //Tiempo maximo que se puede alcanzar si se activa la opción de sumar tiempo al pasar por CheckPoint
    int tiempoRedondeado; //Redondeamos el tiempo para mandarselo al UIManager
    bool activado = true;

    void Start()
    {
        timer = 0; //Empezamos con el tiempo a 0
        tiempoInicio = Time.time; //Tiempo actual en el que se empieza a contar el tiempo
        tiempoMaximo = tiempoMaximoInicial; //Inicializamos el tiempo Máximo
        theUIManager.Tiempo((int)tiempoMaximo);
    }

    void Update()
    {
        if (activado)
        {
            timer = Time.time - tiempoInicio; //Tiempo actual - tiempo en el que empezó

            if ((int)timer != tiempoRedondeado) tics.Play(); //si se cambia de segundo, activamos el tic del reloj

            tiempoRedondeado = (int)timer; //guardamos el tiempo redondeado
            theUIManager.Tiempo((int)tiempoMaximo - tiempoRedondeado); //lo enviamos a la interfaz

            if (tiempoRedondeado > tiempoMaximo - 1) //Si el tiempo que llevamos supera al máximo entonces se resetea el nivel
            {
                ResetNivel(); //Reseteamos el nivel (volvemos al primer checkpoint)
            }
        }
    }

    void ResetNivel() //Reiniciamos el nivel
    {
        GameManager.instance.CheckPoint(Vector2.zero, 0);
        GameManager.instance.Muerte();
        Scene escena = SceneManager.GetActiveScene();
        Transiciones.instance.MakeTransition(escena.buildIndex);
    }

    public void SumarTiempo(float tiempoAdicional) //Si atraviesa un checkpoint y la opción de añadir el tiempo está activado
    {                                              //se suma el tiempo
        tiempoMaximo += tiempoAdicional;
    }

    public void PararTiempo()
    {
        activado = false;
    }
}
