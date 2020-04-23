using System.Collections;
using System.Collections.Generic;
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
        PlayerPrefs.GetInt("saltos", numSaltos);
        PlayerPrefs.GetInt("dash", numDash);
        PlayerPrefs.GetInt("ganchos", numGanchos);
        PlayerPrefs.GetInt("enemigos", numEnemigosDerrotados);
        PlayerPrefs.GetInt("muertes", numMuertes);


        texto.text = "Número de saltos: " + numSaltos + "\n" +
                     "Número de dashes: " + numDash + "\n" +
                     "Número de ganchos: " + numGanchos + "\n" +
                     "Número de enemigos derrotados: " + numEnemigosDerrotados + "\n" +
                     "Número de muertes: " + numMuertes + "\n";
    }
}
