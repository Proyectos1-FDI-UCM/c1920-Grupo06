using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject panel;
    public GameObject puntuacion;
    public GameObject barraProgreso;

    [SerializeField] Image[] vida = null;
    [SerializeField] Image[] powerups = null;
    [SerializeField] Text tiempo = null;
    [SerializeField] Text muertesjugador = null, eliminaciones = null, coleccionablesRecog = null;
    [SerializeField] Text puntos = null;
    [SerializeField] Slider progress = null;

    private void Awake()
    {
        barraProgreso.SetActive(true);
        panel.SetActive(false);
        puntuacion.SetActive(false);
    }

    void Start()
    {
        tiempo.enabled = true;
        GameManager.instance.SetUIManager(this);
        SetMaxHigh(368);//la posicion en y del ultimo gameobject del nivel
        progress.minValue = Camera.main.transform.position.y;
        DesactivaPowerUpSprites();
    }

    private void Update()
    {
        setProgress(Camera.main.transform.position.y);
        //la w y la q para usar los power-ups de plataforma en el aire y el de botas de salto
        if (powerups[1].enabled && Input.GetKeyDown(KeyCode.W)) GameManager.instance.DesactivaSprite(1);
        if (powerups[0].enabled && Input.GetKeyDown(KeyCode.Q)) GameManager.instance.DesactivaSprite(0);
    }
    //APARTADO DE LA BARRA DE PROGRESO
    //método para darle un valor máximo a la barra de vida
    public void SetMaxHigh(int maxHigh)
    {
        progress.maxValue = maxHigh;
    }
    //método para pasar la altura de la cámara y se modifique la barra de progreso en función
    public void setProgress(float high)
    {
        progress.value = high;
    }
    //APARTADO DE LA VIDA
    //desactiva el componente del array vida correspondiente al parametro
    public void SetSpriteLife(int vidas)
    {
        vida[vidas].enabled = false;
    }
    //vuelve a activar todos los sprites
    public void ResetSpritesLife()
    {
        for (int i = 0; i < vida.Length; i++)
        {
            vida[i].enabled = true;
        }
    }
    public void DesactivaSpriteLifes()
    {
        for (int i = 0; i < vida.Length; i++)
        {
            vida[i].enabled = false;
        }
    }
    //APARTADO DE LOS POWER-UPS
    public void DesactivaPowerUpSprites()
    {
        for (int i = 0; i < powerups.Length; i++)
        {
            powerups[i].enabled = false;
        }
    }
    public void ActivaPowerUpSprite(int num)
    {
        powerups[num].enabled = true;
    }
    public void DesActivaPowerUpSprite(int num)
    {
        powerups[num].enabled = false;
    }
    public void Tiempo(int contador)
    {
        if (contador < 10)
        {
            if (contador <= 7)
                if (contador <= 3)
                    tiempo.color = new Color32(255,0,0,255);
                else tiempo.color = new Color32(255, 100, 100, 255);
            else tiempo.color = Color.yellow;
        }
        else tiempo.color = Color.white;
        tiempo.text = contador.ToString();
    }

    public void MostrarPausa()
    {
        panel.SetActive(true);
    }
    public void QuitarPausa()
    {
        panel.SetActive(false);
    }
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
        DesactivaSpriteLifes();
        tiempo.enabled = false;
        DesactivaPowerUpSprites();
    }
}
