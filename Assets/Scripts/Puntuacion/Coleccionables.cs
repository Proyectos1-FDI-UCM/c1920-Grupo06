using UnityEngine;

//Comportamiento de los coleccionables

public class Coleccionables : MonoBehaviour
{
    [SerializeField] int numeroColeccionable = 0; //numero del coleccionable
    AudioSource aud;
    SpriteRenderer sr;
    BoxCollider2D bc;

    private void Start()
    {
        aud = GetComponent<AudioSource>();
        bc = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other) //en caso de colisionar con el jugador
    {
        if (other.gameObject.GetComponent<VidaJugador>() != null)
        {
            aud.Play();
            GameManager.instance.Coleccionable(numeroColeccionable); //activamos el booleano
            bc.enabled = false;
            sr.enabled = false;
            Invoke("Destroy", 0.5f);
        }
    }

    void Destroy()
    {
        Destroy(gameObject); //destruimos el objeto
    }
}
