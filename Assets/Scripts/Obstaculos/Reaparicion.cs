using UnityEngine;
public class Reaparicion : MonoBehaviour
{
    Vector2 posicion;
    float tiempoReactivacion = 3f;

    public bool puedoReaparecer = true;
    private void Awake()
    {
        posicion = transform.position;
    }

    private void OnDisable()
    {
        //si puedo reaparecer, lo hago
        if (puedoReaparecer)
        {
            Invoke("Reactivacion", tiempoReactivacion);
            transform.position = posicion;
        }
    }

    void Reactivacion()
    {
        gameObject.SetActive(true);
    }
}
