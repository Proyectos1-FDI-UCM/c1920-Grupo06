using UnityEngine;
using UnityEngine.SceneManagement;

public class Puntuacion : MonoBehaviour
{
    static int numMuertes1 = 9, numMuertes2 = 4;
    static int enemigosElim1 = 5, enemigosElim2 = 3;
    static int puntuacion1 = 100, puntuacion2 = 1000;

    public static void AñadirPuntuacion(int numMuertes, int enemigosElim, int puntuacion)
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            numMuertes1 += numMuertes;
            enemigosElim1 += enemigosElim;
            puntuacion1 = puntuacion;
        }
        else
        {
            numMuertes2 += numMuertes;
            enemigosElim2 += enemigosElim;
            puntuacion2 = puntuacion;
        }
    }

    public static int GetMuertes()
    {
        return numMuertes1 + numMuertes2;
    }

    public static int GetEnemEliminados()
    {
        return enemigosElim1 + enemigosElim2;
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
        numMuertes1 = 0; numMuertes2 = 0;
        enemigosElim1 = 0; enemigosElim2 = 0;
        puntuacion1 = 0; puntuacion2 = 0;
    }
}
