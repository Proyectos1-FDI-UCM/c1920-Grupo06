using UnityEngine;

//Efecto de movimiento de las nubes en la pantalla de inicio

public class Nubes : MonoBehaviour
{
     [SerializeField] float relacionVelocidad = 20;
    [SerializeField] float distanciaRecorrida = 25;
    float y = 0;
    float posIni;
    private void Start()
    {
        posIni = transform.position.y;
    }

    void Update()
    {
        y = Mathf.PingPong(Time.time * relacionVelocidad, distanciaRecorrida);
        transform.position = new Vector2(transform.position.x, posIni - y);
    }
}