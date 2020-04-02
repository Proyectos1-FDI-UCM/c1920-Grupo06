using UnityEngine;

//Control del comportamiento del menú principal

public class MenuManager : MonoBehaviour
{
    //referencia a los distintos Lerps del menú
    [SerializeField] Lerp lerpIzquierdaScript;
    [SerializeField] Lerp lerpArribaScript;
    [SerializeField] Lerp lerpOrigenScript;

    public void LerpIzquierda() //método para activar el Lerp a la izquierda
    {
        lerpOrigenScript.enabled = false;
        lerpArribaScript.enabled = false;
        lerpIzquierdaScript.enabled = true;
    }

    public void LerpArriba() //método para activar el Lerp hacia arriba
    {
        lerpOrigenScript.enabled = false;
        lerpArribaScript.enabled = true;
        lerpIzquierdaScript.enabled = false;
    }

    public void LerpOrigen() //método para activar el Lerp hacia el origen
    {
        lerpOrigenScript.enabled = true;
        lerpArribaScript.enabled = false;
        lerpIzquierdaScript.enabled = false;
    }
}