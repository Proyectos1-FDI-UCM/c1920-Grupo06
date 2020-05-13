using UnityEngine;
using UnityEngine.UI;

//Script que activa el texto correspondiente en el tutorial

public class ActivacionTextosTutorial : MonoBehaviour
{
    //textos de cada seccion
    [SerializeField] Text seccion1 = null, seccion2 = null, seccion3 = null, seccion4 = null;
    //Referencia al efecto del texto
    EfectoTexto efectoTexto = null;

    void Awake()
    {
        //obtenemos la referencia
        efectoTexto = gameObject.GetComponent<EfectoTexto>();
    }

    void Start()
    {
        //activamos el texto de la primera seccion
        seccion1.enabled = true;
        seccion2.enabled = false;
        seccion3.enabled = false;
        seccion4.enabled = false;
        //establecemos el efecto del texto progresivo
        efectoTexto.EfectoLetrasTexto(seccion1);
    }

    //metodo para activar el texto de la seccion 2
    public void ActivarTextoSeccion2()
    {
        //activamos el texto de la segunda seccion
        seccion1.enabled = false;
        seccion2.enabled = true;
        //establecemos el efecto del texto progresivo
        efectoTexto.EfectoLetrasTexto(seccion2);
    }

    //metodo para activar el texto de la seccion 2
    public void ActivarTextoSeccion3()
    {
        //activamos el texto de la tercera seccion
        seccion2.enabled = false;
        seccion3.enabled = true;
        //establecemos el efecto del texto progresivo
        efectoTexto.EfectoLetrasTexto(seccion3);
    }

    //metodo para activar el texto de la seccion 2
    public void ActivarTextoSeccion4()
    {
        //activamos el texto de la cuarta seccion
        seccion3.enabled = false;
        seccion4.enabled = true;
        //establecemos el efecto del texto progresivo
        efectoTexto.EfectoLetrasTexto(seccion4);
    }
}
