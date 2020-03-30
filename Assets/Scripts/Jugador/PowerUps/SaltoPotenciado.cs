using UnityEngine;

//Comportamiento del PowerUp "SaltoPotenciado"

public class SaltoPotenciado : MonoBehaviour
{
    //multiplicador de longitud de salto y distancia recorrida por el dash; tiempo de desactivación
    [SerializeField] float aumentoAltSalto = 1.5f, aumentoLongDash = 1.5f, tiempo = 10f;
    Salto salto;
    Dash dash;
    bool activado = false; //booleano de control

    void Awake()
    {
        salto = gameObject.GetComponent<Salto>(); //guardamos el componente del salto
        dash = gameObject.GetComponent<Dash>(); //guardamos el componente del dash
        enabled = false; //desactivamos el componente
        activado = true; //ponemos a true el booleano que se encarga de comprobar si se ha desactivado por estar activado de editor
    }

    void OnEnable() //cuando se active el PowerUp
    {
        GameManager.instance.ActivaSprite(2); //activamos su referencia en la interfaz
        salto.PowerUpSalto(salto.GetFuerzaSalto() * aumentoAltSalto); //aumentamos el salto
        dash.PowerUpDash(dash.GetLongitudDash() * aumentoLongDash); //aumentamos el gancho
        Invoke("Desactivar", tiempo); //comenzamos el temporizador que desactiva el powerup
    }

    void Desactivar() //método para desactivar el powerup
    {
        enabled = false;
    }

    void OnDisable() //cuando se desactive e PowerUp
    {
        if (activado) //si no ha sido por editor
        {
            GameManager.instance.DesactivaSprite(2); //desactivamos su referencia en la interfaz
            salto.PowerUpSalto(salto.GetFuerzaSalto() * 1 / aumentoAltSalto); //devolvemos el salto a su valor estándar
            dash.PowerUpDash(dash.GetLongitudDash() * 1 / aumentoLongDash); //devolvemos el dash a su valor estándar
        }
    }
}
