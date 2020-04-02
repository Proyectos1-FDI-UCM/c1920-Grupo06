using UnityEngine;

//Efecto de movimiento de las nubes en la pantalla de inicio

public class Nubes : MonoBehaviour
{
    //distancia que recorre las nubes, velocidad de movimiento
    [SerializeField] float relacionVelocidad = 20;
    [SerializeField] float distanciaRecorrida = 25;
    float y = 0;
    float posIni;

    private void Start()
    {
        //guardamos la posición en 'y'
        posIni = transform.position.y;
    }

    void Update()
    {
        //movemos la nube oscilando en una distancia determinada
        y = Mathf.PingPong(Time.time * relacionVelocidad, distanciaRecorrida);
        transform.position = new Vector2(transform.position.x, posIni - y);
    }
}