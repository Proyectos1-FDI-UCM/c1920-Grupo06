using UnityEngine;

public class Jugador : MonoBehaviour
{
    /*Este es un método que podríaos llamar auxiliar, cuya función es actuar como intermediario entre otros componentes
     *De esta forma ahorramos el mayor número de métodos públicos posibles en los scripts
     */

    GameObject gancho; //Gancho actual
    Vector2 direccionImpulso; //Direccion en la que debe de ir el impulso
    Vector2 direccionDash; //Direccion del Dash
    private void Start()
    {
        GameManager.instance.SetPlayer(gameObject);
        crearGancho = GetComponent<CrearGancho>();
        salto = GetComponent<Salto>();
        estadoJugador = GetComponent<Estados>();
        crearDash = GetComponent<CrearDash>();
    }
    public void Gancho(GameObject NuevoGancho) //Recibe y devuelve una referencia del gancho actual
    {
        gancho = NuevoGancho;

    }
    public GameObject Gancho()
    {
        return gancho;
    }
    public void DireccionImpulso(Vector3 direccion) //Recibe y devuelve la direccion del impulso
    {
        direccionImpulso = direccion;
    }
    public Vector3 DireccionImpulso()
    {
        return direccionImpulso;
    }

    public void DireccionDash(Vector3 direccion) //Recibe y devuelve la dirección del Dash
    {
        direccionDash = direccion;
    }
    public Vector3 DireccionDash()
    {
        return direccionDash;
    }

    //Para recargar las habilidades al tocar el suelo se usan las siguientes variables:

    Estados estadoJugador; //Estados del jugador
    CrearGancho crearGancho; //Script que permite crear Ganchos
    Salto salto; //Script para saltar
    CrearDash crearDash;

    public void RecargaSuelo()
    {
        if (estadoJugador.Estado() == estado.Defecto) //Solo si estoy en posicion por defecto puedo recargar
        {
            crearGancho.RecargaGancho();
            salto.RecargaSalto();
            crearDash.RecargarDash();
        }
    }

   

}
