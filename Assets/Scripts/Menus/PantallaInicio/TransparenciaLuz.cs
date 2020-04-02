using UnityEngine;

//Efecto de transpariencia de la luz en la pantalla de inicio

public class TransparenciaLuz : MonoBehaviour
{
    CanvasGroup luz; //elemento de luz

    void Start()
    {
        //inicializamos su referencia
        luz = GetComponent<CanvasGroup>();
    }

    void Update()
    {
        //variamos ligeramente su alpha, para que sea mayor/menor la visibilidad
        luz.alpha = Mathf.PingPong(Time.time * 2 / 3, 1);
    }
}
