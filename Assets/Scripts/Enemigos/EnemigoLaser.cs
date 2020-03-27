using UnityEngine;

public class EnemigoLaser : MonoBehaviour
{
    [SerializeField] float cadencia = 5f, tiempoApunt = 2f, tiempoescape = 1f;
    [SerializeField] Transform player = null;
    [SerializeField] float anchura_inicial = 0, anchura_final = 0;
    string estado;
    bool visible;
    LineRenderer laser;
    LayerMask mask, mask1;
    RaycastHit2D ray;
    Vector3 apuntar, dir;
    float tiempo;

    private void Start()
    {
        estado = "Siguiendo";
        laser = GetComponent<LineRenderer>();

        mask = LayerMask.GetMask("Escenario");
        mask1 = LayerMask.GetMask("Jugador", "Escenario");

        //asigna un origen al linerenderer y el numero de vértices que tiene
        laser.SetPosition(0, transform.position);
        laser.positionCount = 2;
        tiempo = Time.time;
    }

    private void OnEnable()
    {
        tiempo = Time.time;
    }
    private void OnDisable()
    {
        estado = "Siguiendo";
        laser.startWidth = anchura_inicial;
        laser.endWidth = anchura_inicial;
        laser.material.color = Color.magenta;
    }
    private void Update()
    {
        if (visible)
        {
            laser.enabled = true;
            if (estado == "Siguiendo")
            {
                laser.startWidth = anchura_inicial;
                laser.endWidth = anchura_inicial;

                laser.material.color = Color.magenta;
                dir = player.position - transform.position;

                //el raycast calcula el primer objeto con el que colisiona en direccion al jugador sin colisionar con el jugador
                ray = Physics2D.Raycast(transform.position, dir, 200f, mask);

                if (ray.collider != null)
                {
                    laser.SetPosition(1, CambioZ(ray.point));    
                }
                else laser.SetPosition(1, CambioZ(transform.position));

                if (Time.time >= tiempo + cadencia)
                {
                    CambiaEstado();
                    if (ray.collider != null)
                        apuntar = ray.point;
                }
            }

            else if (estado == "Apuntando")
            {
                //laser.startWidth = (anchura_inicial + anchura_inicial)/2;
                //laser.endWidth = (anchura_inicial + anchura_inicial) / 2;

                laser.material.color = Color.red;

                laser.SetPosition(1, CambioZ(apuntar));
                if (Time.time >= tiempo + tiempoApunt)
                {
                    CambiaEstado();
                }
            }

            else if (estado == "Disparando")
            {
                laser.startWidth = anchura_final;
                laser.endWidth = anchura_final;

                ray = Physics2D.Raycast(transform.position, dir, 200f, mask1);

                if (ray.collider != null && ray.collider.GetComponent<Jugador>() != null)
                {
                    ray.collider.GetComponent<VidaJugador>().EliminaVidaJugador();
                }
                if (Time.time >= tiempo + tiempoescape)
                {
                    CambiaEstado();
                }
            }
        }
        else
        {
            laser.enabled = false;
        }
    }
    private Vector3 CambioZ(Vector3 original) //Cambia un vector para tener la z en menos 1 y que se puede ver junto con los sprites
    {
        return new Vector3(original.x, original.y, -1);
    }
    private void OnBecameVisible()
    {
        visible = true;
    }
    private void OnBecameInvisible()
    {
        visible = false;
    }
    void CambiaEstado()
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
