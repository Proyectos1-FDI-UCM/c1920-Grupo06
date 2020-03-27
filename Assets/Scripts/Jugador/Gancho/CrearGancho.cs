using UnityEngine;

public class CrearGancho : MonoBehaviour
{
    /*Este script es el responsable de crear los ganchos que puede lanzar el jugador
     * Tiene un método público, el cual recarga el gancho cuando "SUelo" ha encontrado una superficie
     * Cambia el estado del jugador a "SlowMotion" cuando se pulsa el mouse 0 y a "LanzamientoGancho" cuando se suelta
     * Este método sólo interactua con "Estados" para cambiar el estado y con el "Gancho" de cada gancho que crea para darle una referencia del juagdor
     * Para hallar el ángulo se usa un método de la clase estática "Métodos" */

    [SerializeField] GameObject gancho = null; //Prefab gancho
    [SerializeField] Transform padreGancho = null; //Padre en la jerarquía de los ganchos para facilitar llevar la cuenta de estos
    [SerializeField] [Range(0, 10)] float longitudLinea = 4; //Longitud de la linea del gancho
    Estados estadoJugador;
    LineRenderer lineaGancho;
    int cargasGancho; //Las cargas que tiene el jugador en cada momento
    int cargasMaxima = 2; //Las cargas máximas que se pueden tener en cada momento, ej. 1 en el nivel 1 y 2 en el nivel 2
    private void Start()
    {
        estadoJugador = GetComponent<Estados>();
        cargasGancho = cargasMaxima;
        lineaGancho = GetComponent<LineRenderer>();
        lineaGancho.positionCount = 2;
        lineaGancho.enabled = false;
    }
    float angulo = 0;
    private void Update()
    {
        float anguloaux = Metodos.anguloConMando(out bool cambio);
        if (cambio) angulo = anguloaux;
        if (padreGancho.childCount < 1) //SI no hay ganchos creados ahora mismo se ejecuta
        {
            if ((Input.GetButtonDown("Gancho") || Input.GetButtonDown("GanchoMando")) && cargasGancho > 0)
            {
                Time.timeScale = 0.1f; //Ralentiza el tiempo mientras se pulsa el el click
                estadoJugador.CambioEstado(estado.SlowMotion);
                lineaGancho.enabled = true;

            }
            if (Input.GetButton("GanchoMando"))
            {
                lineaGancho.SetPosition(0, new Vector3(transform.position.x, transform.position.y, -1));
                lineaGancho.SetPosition(1, puntoLinea(angulo));
            }
            if ((Input.GetButtonUp("Gancho") || Input.GetButtonUp("GanchoMando")) && cargasGancho > 0)
            {
                lineaGancho.enabled = false;

                Time.timeScale = 1; //Vuelve el tiempo normal al soltarlo
                Vector2 posicion = transform.position; posicion.y += .5f; //Se instáncia un poco más arriba del jugador

                if (Input.GetButtonUp("Gancho"))
                    angulo = Metodos.Angulo_Posicion_Mouse(posicion); //Llama a metodos para hallar angulo entre jugador y mouse

                GameObject gancho_nuevo = Instantiate(gancho, posicion, Quaternion.Euler(new Vector3(0, 0, angulo)), padreGancho); //Crea el gancho
                gancho_nuevo.GetComponent<Gancho>().CreacionGancho(gameObject); //Damos una referencia del jugador al gancho
                estadoJugador.CambioEstado(estado.LanzamientoGancho); //Cambiamos al estado creando gancho
                cargasGancho--; //restamos un gancho a los disponibles
            }
        }
    }
    public void RecargaGancho() //Cuando se llama a este método se recarga el gancho
    {
        cargasGancho = cargasMaxima;
    }
    Vector3 puntoLinea(float angulo) //Calcula el segundo punto para la linea del gancho
    {
        float x = Mathf.Cos(angulo) * longitudLinea;
        float y = Mathf.Sin(angulo) * longitudLinea;

        
        return new Vector3(transform.position.x + x, transform.position.y + y, -1);
    }
}
