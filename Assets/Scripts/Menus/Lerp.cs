using UnityEngine;

//Script que da movimiento al canvas del Menu
public class Lerp : MonoBehaviour
{
    //Transforms de puntos hacia los que se hacen los Lerp
    Vector2 startMarker;
    Vector2 endMarker;
    Vector2 origen;

    //Referencias para saber como hacer el movimiento
    [SerializeField] RectTransform rectTransform;
    [SerializeField] string direccion;

   

    //Velocidad de movimiento en unidades por segundo
    public float speed = 200.0F;

    //Tiempo en el que comienza el movimiento
    private float startTime;

    //Distancia total entre los puntos de inicio y final del movimiento
    private float journeyLength;

    private void Awake()
    {
        //Comienza desactivado
        this.enabled = false;
        //Posición original del movimiento
        origen = rectTransform.transform.position;
    }

    void Start()
    {
        startTime = Time.time;

        //Se busca la dirección hacia donde hacer el movimiento y se asignan los valroes
        if(direccion == "derecha")
        {
            //Calculo el punto inicial
            startMarker = new Vector2(rectTransform.transform.position.x, rectTransform.position.y);

            //Calculo el punto final
            endMarker = new Vector2(-0.4f * (rectTransform.transform.position.x), rectTransform.position.y);
        }
        else if(direccion == "arriba")
        {
            startMarker = new Vector2(rectTransform.transform.position.x, rectTransform.position.y);

            endMarker = new Vector2(rectTransform.transform.position.x, 0.4f * rectTransform.position.y);
        }

        journeyLength = Vector2.Distance(startMarker, endMarker);
    }

    //Ocurre lo mismo cuando se reactiva el script
    private void OnEnable()
    {
        startTime = Time.time;


        if (direccion == "derecha")
        {
            //Calculo el punto inicial
            startMarker = new Vector2(rectTransform.transform.position.x, rectTransform.position.y);

            //Calculo el punto final
            endMarker = new Vector2(-0.4f * (rectTransform.transform.position.x), rectTransform.position.y);
        }
        else if (direccion == "origen")
        {
            startMarker = new Vector2(rectTransform.transform.position.x, rectTransform.position.y);

            endMarker = origen;
        }
        else if (direccion == "arriba")
        {
            startMarker = new Vector2(rectTransform.transform.position.x, rectTransform.position.y);

            endMarker = new Vector2(rectTransform.transform.position.x, 0.4f * rectTransform.position.y);
        }
        journeyLength = Vector2.Distance(startMarker, endMarker);
    }

    // Se realiza el movimiento
    void Update()
    {
        //La distancia recorrida es igual al tiempo transcurrido multiplicado por la velocidad.
        float distCovered = (Time.time - startTime) * speed;

        //La fracción del viaje completado es igual a la distancia actual dividida por la distancia total.
        float fractionOfJourney = distCovered / journeyLength;

        //Se establce la posición como una fracción de la distancia entre los marcadores.
        transform.position = Vector2.Lerp(startMarker, endMarker, fractionOfJourney);

        //Si ya se ha superado la distancia de movimiento, se desactiva este script
        if (distCovered > journeyLength) enabled = false;
    }
}