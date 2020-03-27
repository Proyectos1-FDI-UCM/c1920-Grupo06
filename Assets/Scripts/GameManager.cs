using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    static public GameManager instance; //instancia del GM
    [SerializeField] int vidas = 3, tamañoColeccionables = 3; //vidas del jugador, coleccionables
    GameObject jugador = null; //GO del jugador
    Vector3 posicionJugador = Vector3.zero; //posicion del jugador
    Vector3 checkpoint = Vector3.zero; //posicion de la camara
    RetrocederAlCheckPoint retrocederAlCheckPoint;
    UIManager theUIMan = null; //referencia a UIManager
    bool[] coleccionables; //arrays de "coleccionables"

    [Header("Tiempo en segundos del contador")]
    [SerializeField] float timer = 5; //temporizador
    float tiempo; //tiempo original
    int tiempoRedondeado = 0; //tiempo representado en UI
    [SerializeField] bool sumarTiempoCheckPoint = false; //booleano para si añadimos el añadir tiempo al llegar al checkpoint

    private void Awake() //Singleton
    {
        if (instance == null) //si no hay instancia
        {
            instance = this; //la creamos
            DontDestroyOnLoad(gameObject); //evitamos que se destruya entre escenas
        }
        else //en caso contrario
        {
            Destroy(gameObject); //destruimos la instancia
        }
    }

    void Start()
    {
        tiempo = timer;
        coleccionables = new bool[tamañoColeccionables]; //inicializamos el array con respecto al valor del editor
        if (theUIMan != null)
        {
            theUIMan.SetSpriteLife(vidas);
            retrocederAlCheckPoint = Camera.main.GetComponent<RetrocederAlCheckPoint>();
        }
    }

    private void FixedUpdate() //En fixed update para que el tiempo vaya a un ritmo constante
    {
        if (SceneManager.GetActiveScene().name != "Menu")
        {
            timer -= Time.fixedDeltaTime;
        }
    }

    private void Update()
    {
        if (theUIMan != null)
        {
            tiempoRedondeado = (int)timer;
            theUIMan.Tiempo(tiempoRedondeado);
            if (tiempoRedondeado <= 0)
            {
                ResetNivel();
            }
        }
    }

    void ResetNivel()
    {
        timer = tiempo;
        tiempoRedondeado = (int)timer;
        Scene escena = SceneManager.GetActiveScene();
        SceneManager.LoadScene(escena.buildIndex);
        checkpoint = Vector3.zero;
    }

    public void SetUIManager(UIManager uim)
    {
        theUIMan = uim;
    }

    public void SetPlayer(GameObject player)
    {
        jugador = player;
    }

    public void SetRetrocederAlCheckPoint(RetrocederAlCheckPoint RaC)
    {
        retrocederAlCheckPoint = RaC;
    }

    public void EliminaVidaJugador() //método para eliminar vidas del jugador por contacto
    {
        if (vidas > 0)
        {
            theUIMan.SetSpriteLife(vidas);
            vidas--;
        }

        if (vidas <= 0) //si está muerto, volvemos al checkpoint
        {
            Muerte();
            theUIMan.ResetSpritesLife();
        }
    }

    public void PosicionJugador(Vector3 jugadorpos)
    {
        posicionJugador = jugadorpos;
    }

    public void CheckPoint(Vector3 posicion, float tiempoAdicional)
    {
        checkpoint = posicion;
        if (sumarTiempoCheckPoint)
            timer += tiempoAdicional;

    }

    public Vector3 CheckPoint()
    {
        return checkpoint;
    }

    public void Muerte() //método de reaparición
    {
        Time.timeScale = 1;
        jugador.transform.position = checkpoint;
        vidas = 3;
        retrocederAlCheckPoint.enabled = true;
    }

    public void ActivaSprite(int num)
    {
        theUIMan.ActivaPowerUpSprite(num);
    }

    public void DesactivaSprite(int num)
    {
        theUIMan.DesActivaPowerUpSprite(num);
    }

    public void Pausa()
    {
        Time.timeScale = 0;
        theUIMan.MostrarPausa();
    }

    public void QuitarPausa()
    {
        Time.timeScale = 1;
        theUIMan.QuitarPausa();
    }

    public void Coleccionable(int numero) //método de activación del coleccionable obtenido
    {
        coleccionables[numero] = true;
        Debug.Log("Obtenido el coleccionable número " + numero);
    }

    public void ChangeScene(string escena)
    {
        SceneManager.LoadScene(escena);
        Time.timeScale = 1;
        timer = 10;
    }
    public void ChangeScene(int indice)
    {
        SceneManager.LoadScene(indice);
        Time.timeScale = 1;
        timer = 10; 
    }
    public void SalirDelJuego()
    {
        Application.Quit();
    }

}
