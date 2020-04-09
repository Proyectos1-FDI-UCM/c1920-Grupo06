using UnityEngine;

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
    Estados estadoJugador;
    LineRenderer lineaGancho;
    int cargasGancho; //cargas del jugador en cada momento
    int cargasMaxima = 2; //cargas máximas que se pueden tener en cada momento
    float angulo = 0;


    void Start()
    {
        //inicializamos las referencias
        estadoJugador = GetComponent<Estados>();
        lineaGancho = GetComponent<LineRenderer>(); //inicializamos el LineRenderer del gancho (apuntar)
        lineaGancho.positionCount = 2;
        lineaGancho.enabled = false; //lo desactivamos
        cargasGancho = cargasMaxima; //establecemos las cargas actuales
    }

    void Update()
    {
        //comprobamos el ángulo, y lo guardamos en caso de haber variado
        float anguloaux = Metodos.AnguloConMando(out bool cambio);
        if (cambio) angulo = anguloaux;

        if (padreGancho.childCount < 1) //si no hay ganchos creados, se ejecuta
        {
            if ((Input.GetButtonDown("Gancho") || Input.GetButtonDown("GanchoMando")) && cargasGancho > 0)
            {
                Time.timeScale = 0.1f; //ralentiza el tiempo mientras se pulsa el click
                estadoJugador.CambioEstado(estado.SlowMotion); //el jugador pasa al estado SlowMotion
                lineaGancho.enabled = true; //activamos la linea
            }

            if (Input.GetButton("GanchoMando")) //si ha sido activado por mando
            {
                //establecemos la linea de disparo, para facilitar que el jugador apunte bien
                lineaGancho.SetPosition(0, new Vector3(transform.position.x, transform.position.y, -1));
                lineaGancho.SetPosition(1, PuntoLinea(angulo));
            }

            if ((Input.GetButtonUp("Gancho") || Input.GetButtonUp("GanchoMando")) && cargasGancho > 0) //cuando se deje de presionar el botón
            {
                lineaGancho.enabled = false; //se desactiva la linea de apuntado
                Time.timeScale = 1; //devolvemos el tiempo a la normalidad
                //se establece la posición de la aparición del gancho levemente mñas arriba de la del jugador
                Vector2 posicion = transform.position; posicion.y += .5f;

                if (Input.GetButtonUp("Gancho")) //si se ha activado el gancho por ratón
                    angulo = Metodos.AnguloPosicionRaton(posicion); //hallamos el angulo entre jugador y raton

                //instanciamos el gancho
                GameObject gancho_nuevo = Instantiate(gancho, posicion, Quaternion.Euler(new Vector3(0, 0, angulo)), padreGancho);
                gancho_nuevo.GetComponent<Gancho>().CreacionGancho(gameObject); //damos una referencia del jugador al gancho
                estadoJugador.CambioEstado(estado.LanzamientoGancho); //pasamos al estado "LanzamientoGancho"
                cargasGancho--; //restamos un gancho a los disponibles               
            }
        }
    }

    Vector3 PuntoLinea(float angulo) //método para calcular el segundo punto de la linea del gancho
    {
        float x = Mathf.Cos(angulo) * longitudLinea;
        float y = Mathf.Sin(angulo) * longitudLinea;

        //-1 debido a la naturaleza del LineRenderer
        return new Vector3(transform.position.x + x, transform.position.y + y, -1);
    }

    public void RecargaGancho() //metodo para recargar los usos del gancho
    {
        cargasGancho = cargasMaxima;
    }
}
