using UnityEngine;

/* Control de los distintos powerUps en los que puede estar el jugador
 * Se controlas de forma parecida a los estados del jugador
 * Un enum guarda los distintos powerups que pueden conseguirse
 */

public enum powerUp { Ninguno, GanchoAlargado, Nube, SaltoPotenciado, Escudo}
public class PowerUpManager : MonoBehaviour
{
    [SerializeField] float nueva_longitud_gancho = 3;//La nueva longitud del gancho
    [SerializeField] float nueva_fuerza_salto = 3; //La nueva fuerza del salto


    Salto salto;
    Gancho gancho;

    powerUp powerUpActual = powerUp.Ninguno; //Control del powerUp en el que me encuentro

    float valor_inicial_gancho = 0; //Valor inicial para poder resetearlo
    float valor_inicial_salto = 0; 
    private void Awake()
    {
        gancho = GetComponent<Gancho>();
        salto = GetComponent<Salto>(); 

        valor_inicial_gancho = gancho.ValorInicial();
        valor_inicial_salto = salto.GetFuerzaSalto();

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
                gancho.PowerUpGancho(valor_inicial_gancho);
                salto.PowerUpSalto(valor_inicial_salto);
                break;


            case powerUp.GanchoAlargado:
                gancho.PowerUpGancho(nueva_longitud_gancho);
                salto.PowerUpSalto(valor_inicial_salto);
                break;


            case powerUp.Nube:
                gancho.PowerUpGancho(valor_inicial_gancho);
                salto.PowerUpSalto(valor_inicial_salto);
                break;


            case powerUp.SaltoPotenciado:
                gancho.PowerUpGancho(valor_inicial_gancho);
                salto.PowerUpSalto(nueva_fuerza_salto);
                break;


            case powerUp.Escudo:
                gancho.PowerUpGancho(valor_inicial_gancho);
                salto.PowerUpSalto(valor_inicial_salto);
                break;
        }
    }
}
