using UnityEngine;

// Comportamiento de los "tokens" que activan los PowerUps del jugador

public class ActivatePowerUp : MonoBehaviour
{
    [SerializeField] powerUp powerUp = powerUp.Ninguno; //powerUp asignado
    AudioSource aud;
    SpriteRenderer sr;
    BoxCollider2D bc;

    private void Start()
    {
        aud = GetComponent<AudioSource>();
        //bc = GetComponent<BoxCollider2D>();
        //sr = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        PowerUpManager powerUpMan = collision.gameObject.GetComponent<PowerUpManager>(); //se envía el nuevo PowerUp al Manager

        if (powerUpMan != null)
        {
            aud.Play();
            //bc.enabled = false;
            //sr.enabled = false;
            powerUpMan.Manager(powerUp);
            Invoke("Destroy", 0f);
        }
    }

    void Destroy()
    {
        gameObject.SetActive(false); //se desactiva el activador (token)
    }
}
