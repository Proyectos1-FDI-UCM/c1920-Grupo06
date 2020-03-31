using UnityEngine;

//Comportamiento de "EnemigoBalas"

public class EnemigoBalas : MonoBehaviour
{
    [SerializeField] GameObject prefabBalas = null; //prefab de la bala
    [SerializeField] Transform player = null; //referencia al transform del jugador
    [SerializeField] float velocidad = 10f, cadencia = 2f; //velocidad de la bala, cadencia de estas
    GameObject bala;
    bool visible = false, control = false; //booleanos de control
    Vector3 dirBalas, posEnemigo; //dirección de las balas y posición del enemigo
    float tiempo;

    void Start()
    {
        //guardamos la posición del enemigo
        posEnemigo = transform.position;
    }

    void OnEnable() //cuando se active (reaparición)
    {
        //guardamos el tiempo actual
        tiempo = Time.time;
    }

    void OnBecameVisible() //cuando sea visible, activamos el booleano de control
    {
        visible = true;
    }

    void Update()
    {
        //establecemos la dirección de las balas con respecto a donde se encuentra el jugador
        dirBalas = player.position - posEnemigo;

        if (visible) //si el enemigo es visible
        {
            if (!control) //si se puede disparar
            {
                tiempo = Time.time; //actualizamos el tiempo
                //instanciamos la bala
                bala = Instantiate(prefabBalas, posEnemigo, transform.rotation, transform);
                //establecemos la velocidad de la bala
                bala.GetComponent<Rigidbody2D>().velocity = dirBalas.normalized * velocidad;
                //establecemos el control de la cadencia a true
                control = true;
            }
            if (Time.time >= tiempo + cadencia) //cuando ya haya pasado el tiempo de cadencia 
            {
                control = false; //control de cadencia a falso
                tiempo = Time.time; //actualizamos el tiempo
            }
        }
    }

    void OnBecameInvisible() //cuando no sea visible, desactivamos el booleano de control
    {
        visible = false;
    }
}
