using UnityEngine;
using UnityEngine.UI;

//Script que se encarga de reflejar las estadísticas del jugador

public class PantallaEstadisticas : MonoBehaviour
{
    Text texto = null;

    void Start()
    {
        texto = GetComponent<Text>();

        texto.text = "Número de saltos: " + PlayerPrefs.GetInt("saltos") + "\n" +
                     "Número de dashes: " + PlayerPrefs.GetInt("dash") + "\n" +
                     "Número de ganchos: " + PlayerPrefs.GetInt("ganchos") + "\n" +
                     "Número de enemigos derrotados: " + PlayerPrefs.GetInt("enemigos") + "\n" +
                     "Número de muertes: " + PlayerPrefs.GetInt("muertes") + "\n";
    }

    //metodo para poder actualizar al resetear
    public void UpdateText()
    {
        texto.text = "Número de saltos: " + PlayerPrefs.GetInt("saltos") + "\n" +
                     "Número de dashes: " + PlayerPrefs.GetInt("dash") + "\n" +
                     "Número de ganchos: " + PlayerPrefs.GetInt("ganchos") + "\n" +
                     "Número de enemigos derrotados: " + PlayerPrefs.GetInt("enemigos") + "\n" +
                     "Número de muertes: " + PlayerPrefs.GetInt("muertes") + "\n";
    }
}
