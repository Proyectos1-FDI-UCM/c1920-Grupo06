using UnityEngine;

//Script para salir de los créditos

public class Creditos : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKey) GameManager.instance.ChangeScene(0);
    }
}
