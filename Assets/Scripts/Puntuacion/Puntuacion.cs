using UnityEngine;
using UnityEngine.SceneManagement;

public class Puntuacion : MonoBehaviour
{
    static int puntuacion1 = 100, puntuacion2 = 1000;

    public static void AñadirPuntuacion(int puntuacion)
    {
        if (SceneManager.GetActiveScene().buildIndex == 1) puntuacion1 = puntuacion;
        else puntuacion2 = puntuacion;
    }

    public static int GetPuntuacionNivel1()
    {
        return puntuacion1;
    }

    public static int GetPuntuacionNivel2()
    {
        return puntuacion2;
    }

    public static void ResetPuntuacion()
    {
        puntuacion1 = 0; puntuacion2 = 0;
    }
}
