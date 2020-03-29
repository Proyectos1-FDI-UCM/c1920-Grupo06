using UnityEngine;

/* Control de los distintos powerUps en los que puede estar el jugador
 * Se controlas de forma parecida a los estados del jugador
 * Un enum guarda los distintos powerups que pueden conseguirse
 */

public enum powerUp { Ninguno, GanchoAlargado, Nube, SaltoPotenciado, Escudo }
public class PowerUpManager : MonoBehaviour
{
    PlataformaNube nube = null;
    AlargaGancho alargaGancho = null;
    SaltoPotenciado saltoPotenciado = null;
    Escudo escudo = null;
    powerUp powerUpActual = powerUp.Ninguno; //Control del powerUp en el que me encuentro

    private void Awake()
    {
        nube = GetComponent<PlataformaNube>();
        alargaGancho = GetComponent<AlargaGancho>();
        saltoPotenciado = GetComponent<SaltoPotenciado>();
        escudo = GetComponent<Escudo>();

        Manager(powerUp.Ninguno);
    }

    public powerUp PowerUpActual()//Devuelve el powerUp actual
    {
        return powerUpActual;
    }

    public void Manager(powerUp nuevo) //El manager hace que solo haya un power up activo y cambia el power up actual
    {
        powerUpActual = nuevo;
        switch (nuevo)
        {
            case powerUp.Ninguno:
                nube.enabled = false;
                alargaGancho.enabled = false;
                saltoPotenciado.enabled = false;
                escudo.enabled = false;
                break;


            case powerUp.GanchoAlargado:
                alargaGancho.enabled = true;
                saltoPotenciado.enabled = false;
                break;


            case powerUp.Nube:
                nube.enabled = true;
                break;


            case powerUp.SaltoPotenciado:
                alargaGancho.enabled = false;
                saltoPotenciado.enabled = true;
                break;


            case powerUp.Escudo:
                escudo.enabled = true;
                break;
        }
    }
}