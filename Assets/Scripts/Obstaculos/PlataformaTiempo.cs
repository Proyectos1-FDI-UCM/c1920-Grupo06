using UnityEngine;

//Comportamiento de la plataforma Tiempo

public class PlataformaTiempo : MonoBehaviour
{
    [SerializeField] float TiempoDesaparicion = 0; //tiempo de desaparición
    Animator romper = null;
    bool tieneAnimator;
    private void Start()
    {
        tieneAnimator = (GetComponent<Animator>() != null);

        //guardamos el componente animator para la animación de la plataforma
        if (tieneAnimator) romper = GetComponent<Animator>();
    }
    void OnCollisionEnter2D(Collision2D collision) 
    {
        //guardamos los "bounds" y el componente de la colisión 
        Bounds borde = GetComponent<BoxCollider2D>().bounds;
        Estados estados = collision.gameObject.GetComponent<Estados>();

        //si la colisión se produce sobre la plataforma y es el jugador
        if (estados != null && estados.gameObject.transform.position.y > transform.position.y + borde.extents.y)
        {
            if(tieneAnimator) romper.SetBool("Contacto", true); //comienza la animación
            Invoke("Desactivar", TiempoDesaparicion); //hacemos que desaparezca tras cierto tiempo
        }
    }
    void Desactivar() //método para que desaparezca
    {
        if (tieneAnimator)
        {
            //se cambia el estado de animación a "ResetPlatTiempo" que espera al booleano "Contacto"
            romper.SetBool("Reinicio", true);
            //se cambia el valor para que no vuelva a reproducirse la animación hasta que el jugador no vuelva a entrar en contacto con la plataforma
            romper.SetBool("Contacto", false);
        }

        gameObject.SetActive(false);
    }
}
