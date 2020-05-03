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
    SpriteRenderer sr;
    Sprite ori;
    [SerializeField] Sprite disparo = null;

    AudioSource aud;

    void Start()
    {
        aud = GetComponent<AudioSource>();

        //guardamos la posición del enemigo
        posEnemigo = transform.position;
        sr = GetComponent<SpriteRenderer>();
        ori = sr.sprite;
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
                aud.Play();
                sr.sprite = disparo;
                Invoke("FinAnimacion", 0.5f);
                tiempo = Time.time; //actualizamos el tiempo
                //instanciamos la bala
                bala = Instantiate(prefabBalas, transform.GetChild(0).position, transform.rotation, transform);
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

    public void FinAnimacion()
    {
        sr.sprite = ori;
    }
}
