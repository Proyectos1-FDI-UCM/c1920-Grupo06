using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] float tiempoAdicional = 0;
    Transform posicionJugador;
    private void Start()
    {
        posicionJugador = Camera.main.transform;
    }
    private void Update()
    {
        if (posicionJugador.position.y > transform.position.y)
        {
            GameManager.instance.CheckPoint(transform.position, tiempoAdicional);
            Destroy(gameObject);
        }
    }
}
