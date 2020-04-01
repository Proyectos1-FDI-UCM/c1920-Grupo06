using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Lerp lerpIzquierdaScript;
    [SerializeField] Lerp lerpArribaScript;
    [SerializeField] Lerp lerpOrigenScript;

    public void LerpIzquierda()
    {
        lerpOrigenScript.enabled = false;
        lerpArribaScript.enabled = false;
        lerpIzquierdaScript.enabled = true;
    }
    public void LerpArriba()
    {
        lerpOrigenScript.enabled = false;
        lerpArribaScript.enabled = true;
        lerpIzquierdaScript.enabled = false;
    }
    public void LerpOrigen()
    {
        lerpOrigenScript.enabled = true;
        lerpArribaScript.enabled = false;
        lerpIzquierdaScript.enabled = false;
    }
}