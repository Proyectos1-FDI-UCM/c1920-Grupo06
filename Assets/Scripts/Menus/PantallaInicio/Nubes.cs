using UnityEngine;

//Efecto de movimiento de las nubes en la pantalla de inicio

public class Nubes : MonoBehaviour
{
    float y = 0; //movimiento de las nubes

    void Update()
    {
        //la 'y' va alternando levemente de arriba hacia abajo
        y = Mathf.PingPong(Time.time / 20, .1f);
        transform.position = new Vector2(transform.position.x, y);
    }
}
