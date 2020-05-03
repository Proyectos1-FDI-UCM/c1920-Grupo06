using UnityEngine;
//Script que regula la activación de cada movimiento Lerp
public class MenuManager : MonoBehaviour
{
    //Referencias a los script Lerp que producen el movimiento
    [SerializeField] Lerp lerpDerecha = null;
    [SerializeField] Lerp lerpOrigen = null;
    [SerializeField] Lerp lerpArriba = null;
    [SerializeField] Lerp lerpIzquierda = null;

    public void LerpDerecha()
    {
        //Si no se esta produciendo ningún movimiento Lerp, comienza el Lerp
        if (lerpArriba.enabled == false && lerpIzquierda.enabled == false && lerpOrigen.enabled == false && lerpDerecha.enabled == false)
        {
            //Se desactivan los demás Lerp
            lerpDerecha.enabled = true;
            lerpOrigen.enabled = false;
            lerpArriba.enabled = false;
            lerpIzquierda.enabled = false;
        }
    }

    public void LerpOrigen()
    {
        if (lerpArriba.enabled == false && lerpIzquierda.enabled == false && lerpOrigen.enabled == false && lerpDerecha.enabled == false)
        {
            lerpDerecha.enabled = false;
            lerpOrigen.enabled = true;
            lerpArriba.enabled = false;
            lerpIzquierda.enabled = false;
        }
    }

    public void LerpArriba()
    {
        if (lerpArriba.enabled == false && lerpIzquierda.enabled == false && lerpOrigen.enabled == false && lerpDerecha.enabled == false)
        {
            lerpDerecha.enabled = false;
            lerpOrigen.enabled = false;
            lerpArriba.enabled = true;
            lerpIzquierda.enabled = false;
        }
    }
    
    public void LerpIzquierda()
    {
        if (lerpArriba.enabled == false && lerpIzquierda.enabled == false && lerpOrigen.enabled == false && lerpDerecha.enabled == false)
        {
            lerpDerecha.enabled = false;
            lerpOrigen.enabled = false;
            lerpArriba.enabled = false;
            lerpIzquierda.enabled = true;
        }
    }
}