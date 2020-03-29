using UnityEngine;

public class SeguimientoJugador : MonoBehaviour
{
    //Script que se encarga de que la cámara siga al jugador
    [SerializeField]
    Transform jugador = null;
    [SerializeField]
    [Range(0, 20)]
    float velocidad_seguimiento = 10; //Velocidad a la que la cámara sigue al jugador
    bool finalnivel = false;

    private void Start()
    {
        GameManager.instance.SetRetrocederAlCheckPoint(GetComponentInChildren<RetrocederAlCheckPoint>());
    }
    void LateUpdate()
    {
        if (!finalnivel)
        {
            if (jugador.position.y > transform.position.y + 8) //Si el jugador está muy arriba la cámara sube más rápido
            {
                Vector3 pos = transform.position; pos.y += velocidad_seguimiento * Time.deltaTime * 2;
                transform.position = pos;
            }
            else if (jugador.position.y > transform.position.y + 3)//Si el jugador está por encima del punto medio de la cámara ésta sube
            {
                Vector3 pos = transform.position; pos.y += velocidad_seguimiento * Time.deltaTime;
                transform.position = pos;
            }
        }
        else
        {
            Vector3 pos = transform.position;
            pos.y += velocidad_seguimiento * Time.deltaTime / 2;
            transform.position = pos;
        }
    }
    public void Sube()
    {
        finalnivel = true;
    }
}
