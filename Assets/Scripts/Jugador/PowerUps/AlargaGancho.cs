using UnityEngine;

public class AlargaGancho : MonoBehaviour
{
    [SerializeField] float multiplicador = 1.5f, tiempo = 10f;
    [SerializeField] GameObject ganchoGO = null;
    Gancho gancho;
    bool control = false;

    void Awake()
    {
        gancho = ganchoGO.GetComponent<Gancho>(); //guardamos el componente del gancho
        enabled = false; //desactivamos el componente
        control = true; //ponemos a true el booleano que se encarga de comprobar si se ha desactivado por estar activado de editor
    }

    void OnEnable()
    {
        gancho.PowerUpGancho(gancho.GetLongitudGancho() * multiplicador);
        Invoke("Desactivar", tiempo); //comenzamos el temporizador que desactiva el powerup
    }

    void Desactivar() //método para desactivar el powerup
    {
        enabled = false;
    }

    void OnDisable() //cuando se desactive
    {
        if (control) //si no ha sido por editor
        {
            gancho.PowerUpGancho(gancho.GetLongitudGancho() * 1 / multiplicador); //devolvemos el gancho a su valor inicial
        }
    }
}
