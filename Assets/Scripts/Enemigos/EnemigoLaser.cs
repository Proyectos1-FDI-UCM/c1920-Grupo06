using UnityEngine;

//Comportamiento de "EnemigoLaser"

public class EnemigoLaser : MonoBehaviour
{
    //cadencia de disparo, tiempo de apuntado, tiempo de disparo (laser)
    [SerializeField] float cadencia = 5f, tiempoApunt = 2f, tiempoDisparo = 1f;
    [SerializeField] Transform player = null; //referencia al jugador
    [SerializeField] float anchura_inicial = 0, anchura_final = 0; //anchos del laser
    [SerializeField] Sprite s1 = null, s2 = null, s3 = null, s4 = null;
    SpriteRenderer sr;
    LineRenderer laser;
    LayerMask mask, mask1;
    RaycastHit2D ray;
    Vector3 apuntado, dirLaser, spriteRotation; //vectores de apuntado, y de seguimiento, y rotacion del sprite
    string estado; //estado del laser
    bool visible; //booleano de control
    float tiempo; //tiempo (actual)
    float angulo; //rotacion del sprite
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        estado = "Siguiendo";
        laser = GetComponent<LineRenderer>();

        //establecemos los LayerMask
        mask = LayerMask.GetMask("NoEnganchable", "Escenario");
        mask1 = LayerMask.GetMask("Jugador", "NoEnganchable", "Escenario");

        //asigna un origen al LineRenderer y el numero de vértices que tiene
        laser.SetPosition(0, transform.position);
        laser.positionCount = 2;
        tiempo = Time.time;
    }

    void OnEnable() //cuando se active (reaparición)
    {
        tiempo = Time.time; //guardamos el tiempo actual
    }

    void OnBecameVisible() //al hacerse visible, lo especificamos en el booleano de control
    {
        visible = true;
    }

    void Update()
    {
        if (visible) //si está visible
        {
            laser.enabled = true; //activamos el laser (LineRenderer)

            if (estado == "Siguiendo") //si está siguiendo al jugador
            {
                sr.sprite = s2;

                //establecemos la anchura del láser
                laser.startWidth = anchura_inicial;
                laser.endWidth = anchura_inicial;

                //establecemos su color a magenta, y su dirección en relazión a la posición del jugador
                laser.material.color = Color.magenta;
                dirLaser = player.position - transform.position;
                spriteRotation = transform.position - player.position; //vector en el otro sentido para que funcione la rotacion del sprite

                //el raycast calcula el primer objeto con el que colisiona en direccion al jugador sin colisionar con el jugador
                ray = Physics2D.Raycast(transform.position, dirLaser, 200f, mask);

                if (ray.collider != null) //si ha chocado con algún elemento del escenario
                {
                    laser.SetPosition(1, CambioZ(ray.point)); //ponemos el laser donde haya llegado
                    angulo = Mathf.Atan2(spriteRotation.y, spriteRotation.x)*Mathf.Rad2Deg;
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,angulo);
                }
                else laser.SetPosition(1, CambioZ(transform.position)); //si no, lo ponemos con respecto a la posición del enemigo

                if (Time.time >= tiempo + cadencia) //si ha pasado el tiempo de seguimiento
                {
                    CambiaEstado(); //cambiamos de estado
                    if (ray.collider != null) //fijamos la linea de apuntado
                        apuntado = ray.point;
                }
            }
            else if (estado == "Apuntando") //si está apuntando al punto fijo
            {
                sr.sprite = s3;

                laser.material.color = Color.red; //cambiamos el color del laser a rojo
                laser.SetPosition(1, CambioZ(apuntado)); //fijamos su dirección

                if (Time.time >= tiempo + tiempoApunt) //si ha pasado el tiempo de apuntado
                {
                    CambiaEstado(); //cambiamos de estado
                }
            }
            else if (estado == "Disparando") //si esta disparando
            {
                sr.sprite = s4;

                //establecemos su nuevo ancho
                laser.startWidth = anchura_final;
                laser.endWidth = anchura_final;

                //establecemos un raycast que detecte o bien al jugador o bien al escenario
                ray = Physics2D.Raycast(transform.position, dirLaser, 200f, mask1);

                if (ray.collider != null && ray.collider.GetComponent<Jugador>() != null) //si ha chocado con el jugador
                {
                    ray.collider.GetComponent<VidaJugador>().EliminaVidaJugador(); //le quitamos una vida si es posible
                }

                if (Time.time >= tiempo + tiempoDisparo) //si ha pasado el tiempo de disparo
                {
                    CambiaEstado(); //cambiamos de estado                
                }
            }
        }
        else //si no está visible
        {
            laser.enabled = false; //desactivamos el LineRenderer
        }
    }

    void OnBecameInvisible() //si el enemigo laser deja de ser visible, lo notificamos
    {
        visible = false;
    }

    void OnDisable() //cuando se desactiva, dejamos el estado por defecto
    {
        sr.sprite = s1;
        estado = "Siguiendo";
        //hacemos al laser "invisible" con el color de seguimiento
        laser.startWidth = anchura_inicial;
        laser.endWidth = anchura_inicial;
        laser.material.color = Color.magenta;
    }

    Vector3 CambioZ(Vector3 original) //método que cambia un vector para tener la 'z' en -1 y que se pueda ver junto con los sprites
    {
        return new Vector3(original.x, original.y, -1);
    }

    void CambiaEstado() //método que cambia de estado dependiendo del estado anterior
    {
        if (estado == "Siguiendo")
        {
            estado = "Apuntando";
            tiempo = Time.time;
        }
        else if (estado == "Apuntando")
        {
            estado = "Disparando";
            tiempo = Time.time;
        }
        else if (estado == "Disparando")
        {
            estado = "Siguiendo";
            tiempo = Time.time;
        }
    }
}
