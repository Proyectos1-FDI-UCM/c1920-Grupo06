using UnityEngine;

//Script que da movimiento al canvas del Menu
public class Lerp : MonoBehaviour
{
    //Referencias para saber como hacer el movimiento
    [SerializeField] RectTransform rectTransform;
    [SerializeField] string direccion;
    //Velocidad de movimiento en unidades por segundo
    [SerializeField] float velocidad = 200.0F;
    //Transforms de puntos hacia los que se hacen los Lerp
    Vector2 puntoInicio;
    Vector2 puntoFinal;
    Vector2 origen;
    //Tiempo en el que comienza el movimiento
    float tiempoInicio;
    //Distancia total entre los puntos de inicio y final del movimiento
    float distanciaViaje;

    void Awake()
    {
        //Comienza desactivado
        this.enabled = false;
        //Posición original del movimiento
        origen = rectTransform.transform.position;
    }

    void Start()
    {
        tiempoInicio = Time.time;

        //Se busca la dirección hacia donde hacer el movimiento y se asignan los valroes
        if(direccion == "derecha")
        {
            //Calculo el punto inicial
            puntoInicio = origen;

            //Calculo el punto final
            puntoFinal = new Vector2(-0.4f * (origen.x), origen.y);
        }
        else if(direccion == "arriba")
        {
            puntoInicio = origen;

            puntoFinal = new Vector2(origen.x, 0.4f * origen.y);
        }

        distanciaViaje = Vector2.Distance(puntoInicio, puntoFinal);
    }

    //Ocurre lo mismo cuando se reactiva el script
    void OnEnable()
    {
        tiempoInicio = Time.time;


        if (direccion == "derecha")
        {
            //Calculo el punto inicial
            puntoInicio = new Vector2(origen.x, origen.y);

            //Calculo el punto final
            puntoFinal = new Vector2(-0.4f * (origen.x), origen.y);
        }
        else if (direccion == "origen")
        {
            puntoInicio = new Vector2(rectTransform.transform.position.x, rectTransform.transform.position.y);

            puntoFinal = origen;
        }
        else if (direccion == "arriba")
        {
            puntoInicio = new Vector2(origen.x, origen.y);

            puntoFinal = new Vector2(origen.x, 0.4f * origen.y);
        }
        distanciaViaje = Vector2.Distance(puntoInicio, puntoFinal);

        //Si el puntoFinal es el mismo que la posición actual, no hago el movimiento
        if (Mathf.Abs(rectTransform.position.x - puntoFinal.x) < 1 && Mathf.Abs(rectTransform.position.y - puntoFinal.y) < 1)
        {
            enabled = false;
        }
    }

    // Se realiza el movimiento
    void Update()
    {
        //La distancia recorrida es igual al tiempo transcurrido multiplicado por la velocidad.
        float distanciaRecorrida = (Time.time - tiempoInicio) * velocidad;

        //La fracción del viaje completado es igual a la distancia actual dividida por la distancia total.
        float fraccionDeViaje = distanciaRecorrida / distanciaViaje;

        //Se establce la posición como una fracción de la distancia entre los marcadores.
        transform.position = Vector2.Lerp(puntoInicio, puntoFinal, fraccionDeViaje);

        //Si ya se ha superado la distancia de movimiento, se desactiva este script
        if (distanciaRecorrida > distanciaViaje) enabled = false;
    }
}