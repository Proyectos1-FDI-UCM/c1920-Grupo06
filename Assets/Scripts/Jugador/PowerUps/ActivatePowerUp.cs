using UnityEngine;

public class ActivatePowerUp : MonoBehaviour
{
    [SerializeField] powerUp powerUp = powerUp.Ninguno; //powerUp asignado

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PowerUpManager powerUpMan = collision.gameObject.GetComponent<PowerUpManager>(); //se envía el nuevo PowerUp al Manager

        if (powerUpMan != null)
        {
            powerUpMan.Manager(powerUp);
            gameObject.SetActive(false);
        }
    }
}
