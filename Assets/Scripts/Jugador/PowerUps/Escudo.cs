using UnityEngine;

public class Escudo : MonoBehaviour
{
    LayerMask colision = 0;
    [SerializeField] float tiempo = 10f, radioEscudo = 1.3f;
    VidaJugador vidaJugador = null;
    GameObject escudo = null;
    bool activable = true;

    void Awake()
    {
        colision = LayerMask.GetMask("Balas", "Enemigos"); //guardamos los layers que protege el escudo
        vidaJugador = gameObject.GetComponent<VidaJugador>(); //obtenemos la vida del jugador
        escudo = GetEscudo(); //guardamos el sprite del escudo
        escudo.SetActive(false); //lo desactivamos
        enabled = false; //desactivamos el powerup
    }

    void Update()
    {
        if (activable && Input.GetKeyDown("w"))
        {
            escudo.SetActive(true); //activamos el sprtie del escudo
            vidaJugador.HacerInvulnerable(); //hacemos al jugador invulnerable
            Invoke("Desactivar", tiempo); //invocamos un método de desactivación para dentro de x segundos
            activable = false;
        }
    }

    void FixedUpdate()
    {
        Collider2D choque = Physics2D.OverlapCircle(transform.position, radioEscudo, colision); //guardamos con que ha chocado

        if (choque != null && !activable) //si ha chocado con una bala, la destruimos
        {
            if (choque.gameObject.layer == 16) //ESTE IF IF ES POR EL ENABLED
            {
                Destroy(choque.gameObject);
            }
            //enabled = false; //en caso de ser de un solo golpe, lo descomentamos
        }
    }

    GameObject GetEscudo() //método para obtener el escudo
    {
        int i = 0;
        while (i < transform.childCount && transform.GetChild(i).GetComponent<SpriteRenderer>() == null)
        {
            i++;
        }

        return transform.GetChild(i).gameObject;
    }

    void Desactivar() //método para desactivar el powerup
    {
        enabled = false;
    }

    void OnDisable() //al desactivarse
    {
        escudo.SetActive(false); //desactivamos el escudo
        vidaJugador.HacerVulnerable(); //volvemos a hacerlo vulnerable
    }
}
