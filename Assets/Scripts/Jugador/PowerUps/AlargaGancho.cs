using UnityEngine;

//Comportamiento del PowerUp "AlargaGancho"

public class AlargaGancho : MonoBehaviour
{
    //aumento de la longitud del gancho, tiempo para que se desactive
    [SerializeField] float aumentoLongGancho = 1.5f, tiempo = 10f;
    [SerializeField] GameObject ganchoGO = null; //GO del gancho
    Gancho gancho;
    bool control = false; //booleano de control

    void Awake()
    {
        gancho = ganchoGO.GetComponent<Gancho>(); //guardamos el componente del gancho
        enabled = false; //desactivamos el componente
        control = true; //ponemos a true el booleano que se encarga de comprobar si se ha desactivado por estar activado de editor
    }

    void OnEnable() //al activarse el PowerUp
    {
        GameManager.instance.ActivaSprite(3); //activamos su referencia en la interfaz
        gancho.PowerUpGancho(gancho.GetLongitudGancho() * aumentoLongGancho); //alargamos el gancho con respecto al aumento establecido
        Invoke("Desactivar", tiempo); //comenzamos el temporizador que desactiva el powerup
    }

    void Desactivar() //método para desactivar el powerup
    {
        enabled = false;
    }

    void OnDisable() //cuando se desactive el PowerUp
    {
        if (control) //si no ha sido por editor
        {
            GameManager.instance.DesactivaSprite(3); //desactivamos su referencia en la interfaz
            gancho.PowerUpGancho(gancho.GetLongitudGancho() * 1 / aumentoLongGancho); //devolvemos la longitud del gancho a su valor inicial
        }
    }
}
