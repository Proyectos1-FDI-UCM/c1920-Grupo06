using UnityEngine;

//Seguimiento del jugador por parte de la cámara

public class SeguimientoJugador : MonoBehaviour
{
    [SerializeField] Transform jugador = null; //referencia al Transform del jugador
    [SerializeField] [Range(0, 20)] float velocidad_seguimiento = 10; //velocidad a la que la cámara sigue al jugador
    bool finalnivel = false, pararCamara = false;

    void Start()
    {
        //pasamos al GM una referencia al componente de retroceso al checkpoint
        GameManager.instance.SetRetrocederAlCheckPoint(GetComponent<RetrocederAlCheckPoint>());
    }

    void LateUpdate()
    {
        if (!finalnivel) //si no se encuentra en el final del nivel
        {
            if (jugador.position.y > transform.position.y + 8) //si el jugador está muy arriba, la cámara sube el doble de rápido
            {
                Vector3 pos = transform.position;
                pos.y += velocidad_seguimiento * Time.deltaTime * 2;
                transform.position = pos;
            }
            else if (jugador.position.y > transform.position.y + 3)//si el jugador está por encima del punto medio, la cámara sube
            {
                Vector3 pos = transform.position;
                pos.y += velocidad_seguimiento * Time.deltaTime;
                transform.position = pos;
            }
        }
        else //en caso de llegar al final del nivel, la cámara subirá lentamente hasta la pantalla de puntuación
        {
            if (!pararCamara) //si no se ha llamado a Parar
            {
                Vector3 pos = transform.position;
                pos.y += velocidad_seguimiento * Time.deltaTime / 2;
                transform.position = pos;
            }
        }
    }

    public void Sube() //método que permite establecer si se ha llegado o no al final del nivel
    {
        finalnivel = true;
    }

    public void Parar() //metodo para parar la camara tras x tiempo
    {
        pararCamara = true;
    }
}
