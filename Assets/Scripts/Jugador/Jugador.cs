using UnityEngine;

/*Script auxiliar que actúa como intermediario entre otros componentes
 *Así ahorramos el mayor número de métodos públicos posibles en los scripts
 */

public class Jugador : MonoBehaviour
{
    [SerializeField] Estadísticas _estadisticas = null; //Referenia estadísticas
    GameObject gancho; //gancho actual
    Vector2 direccionImpulso; //direccion del impulso
    Vector2 direccionDash; //direccion del Dash

    //para recargar las habilidades al tocar el suelo se usan estas variables
    Estados estadoJugador; //estados del jugador
    CrearGancho crearGancho; //script de creación de ganchos
    Salto salto; //script de salto
    CrearDash crearDash; //script de dash

    public Estadísticas estadisticas
    {
        get
        {
            return _estadisticas;
        }
    }
    void Start()
    {
        //inicialización de los componentes
        GameManager.instance.SetJugador(gameObject);
        crearGancho = GetComponent<CrearGancho>();
        salto = GetComponent<Salto>();
        estadoJugador = GetComponent<Estados>();
        crearDash = GetComponent<CrearDash>();
    }

    public void Gancho(GameObject NuevoGancho) //método para actualizar el gancho
    {
        gancho = NuevoGancho;
    }

    public GameObject Gancho() //método que devuelve el gancho actual
    {
        return gancho;
    }

    public void DireccionImpulso(Vector3 direccion) //método para actualizar la direccion del impulso
    {
        direccionImpulso = direccion;
    }

    public Vector3 DireccionImpulso() //método para devolver la dirección del impulso
    {
        return direccionImpulso;
    }

    public void DireccionDash(Vector3 direccion) //método para actualizar la dirección del dash
    {
        direccionDash = direccion;
    }

    public Vector3 DireccionDash() //método para devolver la dirección del dash
    {
        return direccionDash;
    }

    public void RecargaSuelo() //método para recargar el salto, el dash, y los ganchos disponibles
    {
        if (estadoJugador.Estado() == estado.Defecto) //solo si estoy en posicion por defecto (sobre una plataforma) recargará
        {
            crearGancho.RecargaGancho(); //recargamos los ganchos
            salto.RecargaSalto(); //recargamos el salto
            crearDash.RecargarDash(); //recargamos el dash
        }
    }
}
