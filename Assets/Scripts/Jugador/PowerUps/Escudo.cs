using UnityEngine;

//Comportamiento del PowerUp "Escudo"

public class Escudo : MonoBehaviour
{
    [SerializeField] float tiempo = 10f, radioEscudo = 1.3f; //tiempo de desaparición, y radio del escudo
    LayerMask colision = 0; //capas colisionables con el escudo
    VidaJugador vidaJugador = null;
    GameObject escudo = null;
    bool activable = true; //booleano de control

    void Awake()
    {
        colision = LayerMask.GetMask("Balas", "Enemigos"); //guardamos los layers que protege el escudo
        vidaJugador = gameObject.GetComponent<VidaJugador>(); //obtenemos la vida del jugador
        escudo = ObtenerEscudo(); //guardamos el sprite del escudo
        escudo.SetActive(false); //lo desactivamos
        enabled = false; //desactivamos el powerup
    }

    void OnEnable() //cuando se activa el PowerUp
    {
        GameManager.instance.ActivaSprite(1); //activamos su referencia en la interfaz
    }

    void Update()
    {
        if (activable && Input.GetKeyDown("w")) //cuando se aprete el botón de acción
        {
            escudo.SetActive(true); //activamos el sprite del escudo
            vidaJugador.HacerInvulnerable(); //hacemos al jugador invulnerable
            Invoke("Desactivar", tiempo); //invocamos un método de desactivación para dentro de x segundos
            activable = false;//hacemos que deje de ser posible de activar
        }
    }

    void FixedUpdate()
    {
        Collider2D choque = Physics2D.OverlapCircle(transform.position, radioEscudo, colision); //guardamos con que ha chocado

        if (!activable && choque != null && choque.gameObject.layer == 16) //si ha chocado con una bala, la destruimos
        {
            Destroy(choque.gameObject);
        }
    }

    GameObject ObtenerEscudo() //método para obtener el escudo
    {
        int i = 0;
        //recorremos los hijos en busca del escudo
        while (i < transform.childCount && transform.GetChild(i).GetComponent<SpriteRenderer>() == null)
        {
            i++;
        }

        return transform.GetChild(i).gameObject; //lo devolvemos
    }

    void Desactivar() //método para desactivar el powerup
    {
        enabled = false;
    }

    void OnDisable() //al desactivarse el PowerUp
    {
        escudo.SetActive(false); //desactivamos el escudo
        GameManager.instance.DesactivaSprite(1); //desactivamos su referencia en la interfaz
        vidaJugador.HacerVulnerable(); //volvemos a hacerlo vulnerable
    }
}
