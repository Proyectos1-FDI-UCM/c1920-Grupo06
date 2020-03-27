using UnityEngine;

public class PowerUpSpriteManager : MonoBehaviour
{
    Collider2D powerup;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        powerup = collision;
        if (collision.gameObject.GetComponent<Salto>() != null)
        {
            //como parametro del metodo activasprite habria que pasarle el identifica power-up
            GameManager.instance.ActivaSprite(0);
            Destroy(gameObject);
        }
    }

    /*int IdentificaPowerup()
    {
        int num;
        //si el obejto con el que ha colisionado tiene el componente relacionado con el power-up del escudo
        if (powerup.gameObject.GetComponent<Escudo>()) num = 0; 

        //si el obejto con el que ha colisionado tiene el componente relacionado con el power-up de la plataforma en el aire
        else if (powerup.gameObject.GetComponent<PlataformaAire>()) num = 1;

        //si el obejto con el que ha colisionado tiene el componente relacionado con el power-up del plus del salto y el dash
        else if (powerup.gameObject.GetComponent<PlusSaltoYDash>()) num = 2;

        //en el ultimo caso quedaria el power-up de las botas de salto
        else num = 3;
        return num;
    }*/
}