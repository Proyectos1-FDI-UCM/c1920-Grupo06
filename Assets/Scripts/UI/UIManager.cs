using UnityEngine;
using UnityEngine.UI;

//Comportamiento de la interfaz

public class UIManager : MonoBehaviour
{
    //GO de menú, puntuación y barra de progres
    [SerializeField] GameObject panel = null, puntuacion = null, barraProgreso = null, avance = null;
    //ia¡magenes de la vida y los PowerUps
    [SerializeField] Image[] vida = null, powerups = null;
    //texto de tiempo en pantalla, muertes del jugador, eliminaciones, coleccionables y puntos
    [SerializeField]
    Text tiempo = null, muertesjugador = null, eliminaciones = null,
        coleccionablesRecog = null, puntos = null;
    //slider del progreso en el nivel
    [SerializeField] Slider progress = null;
    [SerializeField] Transform finalNivel = null;

    void Awake()
    {
        //activamos la barra de progreso
        barraProgreso.SetActive(true);
        //desactivamos pantalla de puntuación y pausa
        panel.SetActive(false);
        puntuacion.SetActive(false);
        avance.SetActive(false);
    }

    void Start()
    {
        GameManager.instance.SetUIManager(this); //establecemos a este UIManager en el GM
        tiempo.enabled = true; //activamos el tiempo
        SetAlturaMaxima((int)finalNivel.position.y); //la posicion en 'y' del ultimo GO del nivel
        progress.minValue = Camera.main.transform.position.y; //establecemos el punto mínimo de la barra de progreso
        DesactivaPowerUpSprites(); //desactivamos los sprites de los powerUps
    }

    void Update()
    {
        setProgreso(Camera.main.transform.position.y); //establecemos el avance de la cámara
    }

    //APARTADO DE LA BARRA DE PROGRESO
    public void SetAlturaMaxima(int maxHigh) //método para darle un valor máximo a la barra de progreso
    {
        progress.maxValue = maxHigh;
    }

    public void setProgreso(float high) //método para pasar la altura de la cámara (comienzo de la barra)
    {
        progress.value = high;
    }

    //APARTADO DE LA VIDA
    public void SetSpriteVida(int vidas) //desactiva el componente del array vida correspondiente al parametro
    {
        vida[vidas].enabled = false;
    }
    
    public void ResetSpritesVida() //vuelve a activar todos los sprites
    {
        for (int i = 0; i < vida.Length; i++)
        {
            vida[i].enabled = true;
        }
    }

    public void DesactivaSpriteVidas() //desactiva el array vidas
    {
        for (int i = 0; i < vida.Length; i++)
        {
            vida[i].enabled = false;
        }
    }

    //APARTADO DE LOS POWER-UPS
    public void DesactivaPowerUpSprites() //método que desactiva todos los sprites de powerUps
    {
        for (int i = 0; i < powerups.Length; i++)
        {
            powerups[i].enabled = false;
        }
    }

    public void ActivaPowerUpSprite(int num) //método que activa un sprite de powerUp
    {
        powerups[num].enabled = true;
    }

    public void DesactivaPowerUpSprite(int num) //método que desactiva un sprite de powerUp
    {
        if (powerups[num] != null)
        {
            powerups[num].enabled = false;
        }
    }

    //APARTADO DEL TIEMPO
    public void Tiempo(int contador) //método para establecer el tiempo en pantalla
    {
        //cambiamos el color del texto con respecto al tiempo que quede
        if (contador < 10)
        {
            if (contador <= 7)
            {
                if (contador <= 3) tiempo.color = new Color32(255, 0, 0, 255);
                else tiempo.color = new Color32(255, 100, 100, 255);
            }
            else tiempo.color = Color.yellow;
        }
        else tiempo.color = Color.white;

        //escribimos el tiempo
        tiempo.text = contador.ToString();
    }

    //APARTADO DE LA PAUSA
    public void MostrarPausa() //método que activa el menú de pausa
    {
        panel.SetActive(true);
    }

    public void QuitarPausa() //método que deactiva el menú de pausa
    {
        panel.SetActive(false);
    }

    //APARTADO DE LA PUNTUACIÓN
    //método para enseñar ka puntuación en la pantalla
    public void MostrarPuntuacion(int punt, int muertes, int enemigoselim, int coleccionables)
    {
        //muestra el marco con la puntuacion
        puntuacion.SetActive(true);
        muertesjugador.text = "X" + muertes.ToString();
        eliminaciones.text = "X" + enemigoselim.ToString();
        coleccionablesRecog.text = "X" + coleccionables.ToString();
        puntos.text = "PUNTUACIÓN: " + punt.ToString();

        //oculta la barra de progreso, la vidas, el tiempo y los sprites de los power-ups
        barraProgreso.SetActive(false);
        DesactivaSpriteVidas();
        tiempo.enabled = false;
        DesactivaPowerUpSprites();
    }

    //metodo para activar el boton de avance de nivel
    public void ActivarBotonAvance()
    {
        avance.SetActive(true);
    }
}
