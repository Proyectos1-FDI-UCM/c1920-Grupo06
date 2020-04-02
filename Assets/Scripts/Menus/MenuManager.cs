using UnityEngine;
using UnityEngine.UI;
//Script que regula la activación de cada movimiento Lerp
public class MenuManager : MonoBehaviour
{
    //Referencias a los script Lerp que producen el movimiento
    [SerializeField] Lerp lerpDerecha;
    [SerializeField] Lerp lerpOrigen;
    [SerializeField] Lerp lerpArriba;
    //Referencias a los botones usados
    //[SerializeField] GameObject botonOpciones;
    //[SerializeField] GameObject botonJugar;

    public void LerpDerecha()
    {
        //Si no se esta produciendo ningún movimiento Lerp, comienza el Lerp
        if (lerpArriba.enabled == false && lerpOrigen.enabled == false && lerpDerecha.enabled == false)
        {
            lerpDerecha.enabled = true;
            lerpOrigen.enabled = false;
            lerpArriba.enabled = false;
            //botonOpciones.GetComponent<Button>().interactable = false;
        }
    }

    public void LerpOrigen()
    {
        if (lerpArriba.enabled == false && lerpOrigen.enabled == false && lerpDerecha.enabled == false)
        {
            lerpDerecha.enabled = false;
            lerpOrigen.enabled = true;
            lerpArriba.enabled = false;
        }
    }

    public void LerpArriba()
    {
        if (lerpArriba.enabled == false && lerpOrigen.enabled == false && lerpDerecha.enabled == false)
        {
            lerpDerecha.enabled = false;
            lerpOrigen.enabled = false;
            lerpArriba.enabled = true;
        }
    }

}