using UnityEngine;

/* Control de los distintos powerUps en los que puede estar el jugador.
 * Un enum guarda los distintos powerups que pueden conseguirse
 */

//enum de los PowerUps
public enum powerUp { Ninguno, GanchoAlargado, Nube, SaltoPotenciado, Escudo }

public class PowerUpManager : MonoBehaviour
{
    //referencias a los cuatro PowerUps
    PlataformaNube nube = null;
    AlargaGancho alargaGancho = null;
    SaltoPotenciado saltoPotenciado = null;
    Escudo escudo = null;
    powerUp powerUpActual = powerUp.Ninguno; //powerUp en el que me encuentro

    private void Awake()
    {
        //obtenemos referencia a todos los PowerUps
        nube = GetComponent<PlataformaNube>();
        alargaGancho = GetComponent<AlargaGancho>();
        saltoPotenciado = GetComponent<SaltoPotenciado>();
        escudo = GetComponent<Escudo>();

        //actualizamos su estado
        Manager(powerUp.Ninguno);
    }

    public powerUp PowerUpActual() //método que devuelve el powerUp actual
    {
        return powerUpActual;
    }

    public void Manager(powerUp nuevo) //Manager que activa/desactiva PowerUps dependiendo del nuevo obtenido
    {
        powerUpActual = nuevo; //actalizamos el powerUp
        switch (nuevo)
        {
            case powerUp.Ninguno: //desactivamos todos los PowerUps
                nube.enabled = false;
                alargaGancho.enabled = false;
                saltoPotenciado.enabled = false;
                escudo.enabled = false;
                break;


            case powerUp.GanchoAlargado:
                alargaGancho.enabled = true; //activamos el alarga-gancho
                saltoPotenciado.enabled = false; //Desactivamos el salto potenciado (si estuviese activado)
                break;


            case powerUp.Nube:
                nube.enabled = true; //activamos el powerUp de la nube (script)
                break;


            case powerUp.SaltoPotenciado:
                alargaGancho.enabled = false; //activamos el salto potenciado
                saltoPotenciado.enabled = true; //desactivamos el alarga-gancho (si estuviese activado)
                break;


            case powerUp.Escudo:
                escudo.enabled = true; //activamos el escudo (script)
                break;
        }
    }
}