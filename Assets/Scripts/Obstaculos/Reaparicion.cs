using UnityEngine;

//Control de la reaparición de aquellos elementos que 

public class Reaparicion : MonoBehaviour
{
    [SerializeField] bool puedoReaparecer = true; //booleano que decide si la entidad reaparece o no
    [SerializeField] float tiempoReactivacion = 3f; //tiempo que tarda en reaparecer
    Vector2 posicion; //posicion de la entidad
    bool activarParticulas = true;
    ParticulasMuerteEnemigos particulas = null;

    private void Start()
    {
        particulas = GetComponent<ParticulasMuerteEnemigos>();
    }

    void Awake()
    {
        //guardamos la posición de la entidad
        posicion = transform.position;
    }

    void OnDisable() //al desactivarse
    {
        //Activo las partículas, que solo aparecerán si es un enemigo
        if (particulas != null && activarParticulas && !GameManager.instance.GetBoolSceneChanged()) particulas.Activar();
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

    private void OnApplicationQuit()
    {
        activarParticulas = false;
    }
}
