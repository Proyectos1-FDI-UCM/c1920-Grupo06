using UnityEngine;
using UnityEngine.UI;

public class PantallaPuntuacion : MonoBehaviour
{
    [SerializeField] Text muertes, enemigos, puntuacionNivel1, puntuacionNivel2;
    bool reset = false;

    void Start()
    {
        SetEstadisticas();
    }

    void Update()
    {
        if (reset)
        {
            SetEstadisticas();
            reset = false;
        }
    }

    void SetEstadisticas()
    {
        muertes.text = Puntuacion.GetMuertes().ToString();
        enemigos.text = Puntuacion.GetEnemEliminados().ToString();
        puntuacionNivel1.text = Puntuacion.GetPuntuacionNivel1().ToString();
        puntuacionNivel2.text = Puntuacion.GetPuntuacionNivel2().ToString();
    }

    public void ResetPantallaPuntuación()
    {
        Puntuacion.ResetPuntuacion();
        reset = true;
    }
}
