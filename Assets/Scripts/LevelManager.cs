using UnityEngine;

//Script que se encarga de activar el nivel 2 en Menu (booleano)

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance = null;
    bool nivel2 = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    void Update()
    {
        Debug.Log(nivel2);
    }

    public void ActivarNivel2()
    {
        nivel2 = true;
    }

    public bool Nivel2()
    {
        return nivel2;
    }
}
