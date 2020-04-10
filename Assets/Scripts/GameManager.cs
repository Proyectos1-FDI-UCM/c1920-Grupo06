using UnityEngine;
using UnityEngine.SceneManagement;

//Comportamiento del GameManager

public class GameManager : MonoBehaviour
{
    static public GameManager instance; //instancia del GM
    [SerializeField] int vidas = 3, tamañoColeccionables = 3; //vidas del jugador, coleccionables
    Estadisticas estadisticas = null;
    GameObject jugador = null; //GO del jugador
    RetrocederAlCheckPoint retrocederAlCheckPoint;
    UIManager theUIMan = null; //referencia a UIManager
    Vector3 posicionJugador = Vector3.zero; //posicion del jugador
    Vector3 checkpoint = Vector3.zero; //posicion de la camara
    int enemigosElim = 0, numMuertes = 0, puntuacion = 0; //contador de veces que el jugador muere y enemigos que elimina y puntuacion
    bool[] coleccionables; //arrays de "coleccionables"

    //variables de puntuacion
    [SerializeField] int puntuacionPorMuerte = 0, puntuacionPorEnemigo = 0, puntuacionPorColeccionable = 0;
    SeguimientoJugador finalcam;
    Estados estados;

    //variables de tiempo
    [SerializeField] bool sumarTiempoCheckPoint = false; //booleano para si añadimos el añadir tiempo al llegar al checkpoint
    [SerializeField] Timer timer;
    private void Awake() //singleton
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
        if (theUIMan != null) //si hay UIManager
        {
            theUIMan.SetSpriteVida(vidas); //establecemos las vidas
        }
        //guardamos referencias a los componentes de la cámara
        retrocederAlCheckPoint = Camera.main.GetComponent<RetrocederAlCheckPoint>();
        finalcam = Camera.main.GetComponent<SeguimientoJugador>();
        coleccionables = new bool[tamañoColeccionables]; //inicializamos el array con respecto al valor del editor
    }

    //CHECKPOINTS

    public void CheckPoint(Vector3 posicion, float tiempoAdicional) //método para establecer el nuevo checkpoint
    {
        checkpoint = posicion;
        if (sumarTiempoCheckPoint)
            timer.SumarTiempo(tiempoAdicional);

    }

    public Vector3 CheckPoint() //método para obtener el checkpoint actual
    {
        return checkpoint;
    }

    //SISTEMA DE VIDAS
    public void EliminaVidaJugador() //método para eliminar vidas del jugador por contacto
    {
        if (vidas > 0) //si las vidas son mayores que 0
        {
            //quitamos una vida (reflejado en la interfaz)
            theUIMan.SetSpriteVida(vidas);
            vidas--;
        }

        if (vidas <= 0) //si está muerto, volvemos al checkpoint
        {
            Muerte();
            theUIMan.ResetSpritesVida();
        }
    }

    public void Muerte() //método de reaparición
    {
        estadisticas.Muerte();//Sumamos uno a las muertes

        theUIMan.ResetSpritesVida(); //reseteamos las vidas
        vidas = 3;
        retrocederAlCheckPoint.enabled = true; //retrocedemos al checkpoint
        Time.timeScale = 1; //activamos el tiempo a 1 (en caso de reiniciar desde menu)
        numMuertes++; //aumentamos el número de muertes
        jugador.transform.position = checkpoint; //hacemos que el jugador se transporte al checkpoint
    }

    //POWERUPS (INTERFAZ)
    public void ActivaSprite(int num) //método hace activar un sprite del PowerUp a la interfaz
    {
        theUIMan.ActivaPowerUpSprite(num);
    }

    public void DesactivaSprite(int num) //método hace desactivar un sprite del PowerUp a la interfaz
    {
        theUIMan.DesactivaPowerUpSprite(num);
    }

    //PAUSA
    public void Pausa() //método para mostrar el menu de pausa
    {
        Time.timeScale = 0;
        theUIMan.MostrarPausa();
    }

    public void QuitarPausa() //método para quitar el menú de pausa
    {
        Time.timeScale = 1;
        theUIMan.QuitarPausa();
    }

    public void ChangeScene(string escena) //método de cambio de escena
    {
        SceneManager.LoadScene(escena);
        Time.timeScale = 1;
    }

    public void ChangeScene(int indice) //método de cambio de escena
    {
        SceneManager.LoadScene(indice);
        Time.timeScale = 1;
    }

    public void SalirDelJuego() //método para salir del juego
    {
        Application.Quit();
    }
    
    //PUNTUACION
    public void Puntuacion() //metodo que proporciona la informacion de las vidas, enemigos eliminados y los coleccionables obtenidos
    {
        //bucle para contar cuantos coleccionables se han obtenido
        int coleccionablesObt = 0;
        for (int i = 0; i < coleccionables.Length; i++)
        {
            if (coleccionables[i]) coleccionablesObt++;
        }
        //calculamos la puntuación y la enviamos a la interfaz
        puntuacion = CalculaPuntuacion(numMuertes, enemigosElim, coleccionablesObt);
        theUIMan.MostrarPuntuacion(puntuacion, numMuertes, enemigosElim, coleccionablesObt);
        //cambiamos el estado a inactivo
        estados = jugador.GetComponent<Estados>();
        estados.CambioEstado(estado.Inactivo);
        //hacemos que la cámara suba
        SeguimientoJugador cam = Camera.main.GetComponent<SeguimientoJugador>();
        cam.Sube();
    }
    
    public void ContadorEnemigosElim() //método que aumenta el contador en 1 al eliminar a un enemigo
    {
        enemigosElim++;
    }

    int CalculaPuntuacion(int muertes, int enemies, int coleccionables) //método para calcular la puntuación
    {
        int punt = (muertes * puntuacionPorMuerte) + (enemies * puntuacionPorEnemigo) + (coleccionables * puntuacionPorColeccionable);
        if (punt > 0) return punt;
        else return 0; //si la puntuación es negativa, devolvemos 0
    }

    public void Coleccionable(int numero) //método de activación del coleccionable obtenido
    {
        coleccionables[numero] = true;
        Debug.Log("Obtenido el coleccionable número " + numero);
    }

    //SETTERS
    public void SetUIManager(UIManager uim) //establece el UIManager
    {
        theUIMan = uim;
    }

    public void SetJugador(GameObject player) //establece el jugador
    {
        jugador = player;
        estadisticas = jugador.GetComponent<Jugador>().estadisticas;
    }

    public void SetRetrocederAlCheckPoint(RetrocederAlCheckPoint RaC) //estblece el componente retroceder de la cámara
    {
        retrocederAlCheckPoint = RaC;
    }
}
