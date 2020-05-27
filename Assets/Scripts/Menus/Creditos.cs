using UnityEngine;

//Script para salir de los créditos

public class Creditos : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown) Transiciones.instance.MakeTransition(0);
    }
}
