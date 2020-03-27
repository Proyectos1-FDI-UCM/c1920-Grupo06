using UnityEngine;

public class SaltoPotenciado : MonoBehaviour
{
    [SerializeField] float multiplicadorSalto = 1.5f, multiplicadorDash = 1.5f, tiempo = 10f;
    Salto salto;
    Dash dash;
    bool activado = false;

    void Awake()
    {
        salto = gameObject.GetComponent<Salto>(); //guardamos el componente del salto
        dash = gameObject.GetComponent<Dash>(); //guardamos el componente del dash
        enabled = false; //desactivamos el componente
        activado = true; //ponemos a true el booleano que se encarga de comprobar si se ha desactivado por estar activado de editor
    }

    void OnEnable() //cuando se active
    {
        salto.PowerUpSalto(salto.GetFuerzaSalto() * multiplicadorSalto); //aumentamos el salto
        dash.PowerUpDash(dash.GetLongitudDash() * multiplicadorDash); //aumentamos el gancho
        Invoke("Desactivar", tiempo); //comenzamos el temporizador que desactiva el powerup
    }

    void Desactivar() //método para desactivar el powerup
    {
        enabled = false;
    }

    void OnDisable() //cuando se desactive
    {
        if (activado) //si no ha sido por editor
        {
            salto.PowerUpSalto(salto.GetFuerzaSalto() * 1 / multiplicadorSalto); //devolvemos el salto a su valor estándar
            dash.PowerUpDash(dash.GetLongitudDash() * 1 / multiplicadorDash); //devolvemos el dash a su valor estándar
        }
    }
}
