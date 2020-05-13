using UnityEngine;
using UnityEngine.UI;

public class PantallaEstadisticas : MonoBehaviour
{
    Text texto = null;

    void Start()
    {
        texto = GetComponent<Text>();

        int numSaltos = 0, 
            numDash = 0, 
            numGanchos = 0, 
            numEnemigosDerrotados = 0,
            numMuertes = 0;
        numSaltos = PlayerPrefs.GetInt("saltos");
        numDash = PlayerPrefs.GetInt("dash");
        numGanchos = PlayerPrefs.GetInt("ganchos");
        numEnemigosDerrotados = PlayerPrefs.GetInt("enemigos");
        numMuertes = PlayerPrefs.GetInt("muertes");


        texto.text = "Número de saltos: " + numSaltos + "\n" +
                     "Número de dashes: " + numDash + "\n" +
                     "Número de ganchos: " + numGanchos + "\n" +
                     "Número de enemigos derrotados: " + numEnemigosDerrotados + "\n" +
                     "Número de muertes: " + numMuertes + "\n";
    }
}
