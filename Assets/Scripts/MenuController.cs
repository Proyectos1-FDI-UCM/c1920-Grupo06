using UnityEngine.UI;
using UnityEngine;

/*Script que controla los botones del menu principal, desactivandolos al estar en una de sus 
  pantallas secundarias, y activandolos al volver a la pantalla principal*/

public class MenuController : MonoBehaviour
{
    //botones e imagenes de la pantalla principal
    [SerializeField] Button jugar = null, estadisticas = null, opciones = null, salir = null;
    Image jugarImagen = null, estadisticasImagen = null, opcionesImagen = null, salirImagen = null;


    void Awake() //obtenemos referencia a las imagenes
    {
        jugarImagen = jugar.gameObject.GetComponent<Image>();
        estadisticasImagen = estadisticas.gameObject.GetComponent<Image>();
        opcionesImagen = opciones.gameObject.GetComponent<Image>();
        salirImagen = salir.gameObject.GetComponent<Image>();
    }

    //metodo para activar los botones
    public void ActivarBotones() //metodo para activar los botones
    {
        jugar.enabled = true;
        jugarImagen.enabled = true;
        estadisticas.enabled = true;
        estadisticasImagen.enabled = true;
        opciones.enabled = true;
        opcionesImagen.enabled = true;
        salir.enabled = true;
        salirImagen.enabled = true;
    }

    //metodo para desactivar los botones (tenemos que desactivar imagenes porque si no se ponen en blanco)
    public void DesactivarBotones()
    {
        jugar.enabled = false;
        jugarImagen.enabled = false;
        estadisticas.enabled = false;
        estadisticasImagen.enabled = false;
        opciones.enabled = false;
        opcionesImagen.enabled = false;
        salir.enabled = false;
        salirImagen.enabled = false;
    }
}
