using UnityEngine;

//Control de la reaparición de aquellos elementos que 

public class Reaparicion : MonoBehaviour
{
    [SerializeField] bool puedoReaparecer = true; //booleano que decide si la entidad reaparece o no
    [SerializeField] float tiempoReactivacion = 3f; //tiempo que tarda en reaparecer
    Vector2 posicion; //posicion de la entidad

    void Awake()
    {
        //guardamos la posición de la entidad
        posicion = transform.position;
    }

    void OnDisable() //al desactivarse
    {
        //si puedo reaparecer
        if (puedoReaparecer)
        {
            //lo hago tras cierto tiempo
            Invoke("Reactivacion", tiempoReactivacion);
            transform.position = posicion;
        }
    }

    void Reactivacion() //método para la reactivación de la entidad
    {
        gameObject.SetActive(true);
    }
}
