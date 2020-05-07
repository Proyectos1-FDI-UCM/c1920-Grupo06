using UnityEngine;
using UnityEngine.UI;

public class ActivacionTextosTutorial : MonoBehaviour
{
    [SerializeField] Text seccion1 = null, seccion2 = null, seccion3 = null, seccion4 = null;

    void Start()
    {
        seccion1.enabled = true;
        seccion2.enabled = false;
        seccion3.enabled = false;
        seccion4.enabled = false;
    }

    public void ActivarTextoSeccion2()
    {
        seccion1.enabled = false;
        seccion2.enabled = true;
    }
    
    public void ActivarTextoSeccion3()
    {
        seccion2.enabled = false;
        seccion3.enabled = true;
    }
    
    public void ActivarTextoSeccion4()
    {
        seccion3.enabled = false;
        seccion4.enabled = true;
    }
    
    public void Final()
    {
        seccion4.enabled = false;
    }
}
