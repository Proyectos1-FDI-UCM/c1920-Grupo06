using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparenciaLuz : MonoBehaviour
{
    CanvasGroup luz;


    private void Start()
    {
        luz = GetComponent<CanvasGroup>();
    }
    private void Update()
    {
        luz.alpha = Mathf.PingPong(Time.time * 2 / 3, 1);
    }
}
