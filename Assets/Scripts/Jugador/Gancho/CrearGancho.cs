﻿using UnityEngine;

/* Este script es el responsable de crear los ganchos que puede lanzar el jugador
 * Tiene un método público, el cual recarga el gancho cuando "SUelo" ha encontrado una superficie
 * Cambia el estado del jugador a "SlowMotion" cuando se pulsa el mouse 0 y a "LanzamientoGancho" cuando se suelta
 * Este método sólo interactua con "Estados" para cambiar el estado y con el "Gancho" de cada gancho que crea para darle una referencia del juagdor
 * Para hallar el ángulo se usa un método de la clase estática "Métodos" */

public class CrearGancho : MonoBehaviour
{

    [SerializeField] GameObject gancho = null; //prefab del gancho
    [SerializeField] Transform padreGancho = null; //padre de los ganchos, para facilitar llevar la cuenta de estos
    [SerializeField] [Range(0, 10)] float longitudLinea = 4; //longitud del gancho
    Estadisticas estadisticas = null; //Referencia de las estadisticas
    Estados estadoJugador;
    int cargasGancho; //cargas del jugador en cada momento
    int cargasMaxima = 2; //cargas máximas que se pueden tener en cada momento
    float angulo = 0;
    Suelo suelo;
    AudioSource aud;
    AudioSource[] audAux;

    void Start()
    {
        //inicializamos las referencias
        estadoJugador = GetComponent<Estados>();
        cargasGancho = cargasMaxima; //establecemos las cargas actuales
		estadisticas = GetComponent<Jugador>().estadisticas;
		suelo = transform.GetChild(0).GetComponent<Suelo>(); //Los pies deben ser el primer hijo del jugador
        audAux = GetComponentsInChildren<AudioSource>();
        aud = audAux[Metodos.EncuentraAudioSource(audAux,"Gancho")];
    }

    void Update()
    {
        //comprobamos el ángulo, y lo guardamos en caso de haber variado
        float anguloaux = Metodos.AnguloConMando(out bool cambio);
        if (cambio) angulo = anguloaux;

        if (padreGancho.childCount < 1) //si no hay ganchos creados, se ejecuta
        {
            if (Input.GetButtonDown("Gancho")  && cargasGancho > 0)
            {
                Time.timeScale = 0.1f; //ralentiza el tiempo mientras se pulsa el click
                estadoJugador.CambioEstado(estado.SlowMotion); //el jugador pasa al estado SlowMotion
            }

            

            if (Input.GetButtonUp("Gancho")  && cargasGancho > 0) //cuando se deje de presionar el botón
            {
                estadisticas.Gancho();//Sumamos un gancho a las estadísticas

                Time.timeScale = 1; //devolvemos el tiempo a la normalidad
                //se establece la posición de la aparición del gancho levemente mñas arriba de la del jugador
                Vector2 posicion = transform.position; posicion.y += .5f;

                    angulo = Metodos.AnguloPosicionRaton(posicion); //hallamos el angulo entre jugador y raton

				//Si se está apuntando al suelo desde el suelo no se crea un gancho
                if ((angulo > 240 || angulo < -60) && suelo.EnSuelo())
                {
                    estadoJugador.CambioEstado(estado.Defecto);
                }
                else
                {
                    //instanciamos el gancho
                    GameObject gancho_nuevo = Instantiate(gancho, posicion, Quaternion.Euler(new Vector3(0, 0, angulo)), padreGancho);
                    gancho_nuevo.GetComponent<Gancho>().CreacionGancho(gameObject); //damos una referencia del jugador al gancho
                    estadoJugador.CambioEstado(estado.LanzamientoGancho); //pasamos al estado "LanzamientoGancho"
                    cargasGancho--; //restamos un gancho a los disponibles
                    aud.Play();
                }
            }
        }
    }

    public void RecargaGancho() //metodo para recargar los usos del gancho
    {
        cargasGancho = cargasMaxima;
    }
}