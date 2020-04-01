using UnityEngine;

public class TransparenciaLuz : MonoBehaviour
{
    CanvasGroup luz;

    void Start()
    {
        luz = GetComponent<CanvasGroup>();
    }

    void Update()
    {
        luz.alpha = Mathf.PingPong(Time.time * 2 / 3, 1);
    }
}
