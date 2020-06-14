using UnityEngine;
using UnityEngine.UI;

public class PantallaPuntuacion : MonoBehaviour
{
    [SerializeField] Text puntuacionNivel1 = null, puntuacionNivel2 = null;
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
        puntuacionNivel1.text = Puntuacion.GetPuntuacionNivel1().ToString();
        puntuacionNivel2.text = Puntuacion.GetPuntuacionNivel2().ToString();
    }

    public void ResetPantallaPuntuación()
    {
        Puntuacion.ResetPuntuacion();
        reset = true;
    }
}
