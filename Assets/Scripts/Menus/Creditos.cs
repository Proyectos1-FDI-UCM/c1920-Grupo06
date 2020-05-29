using UnityEngine;

//Script para salir de los créditos

public class Creditos : MonoBehaviour
{
    bool pulsado = false;
    void Update()
    {
        if (Input.anyKeyDown && !pulsado)
        {
            Transiciones.instance.MakeTransition(0);
            pulsado = true;
        }
    }
}
