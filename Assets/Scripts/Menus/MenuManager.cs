using UnityEngine;

//Script que regula la activación de cada movimiento Lerp
public class MenuManager : MonoBehaviour
{
    [SerializeField] Lerp lerpDerecha;
    [SerializeField] Lerp lerpOrigen;
    [SerializeField] Lerp lerpArriba;


    public void LerpDerecha()
    {
        //Si no se esta produciendo ningún movimiento Lerp
        if(lerpArriba.enabled == false && lerpOrigen.enabled == false && lerpDerecha.enabled == false)
        {
        lerpDerecha.enabled = true;
        lerpOrigen.enabled = false;
        lerpArriba.enabled = false;
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