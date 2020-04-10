using UnityEngine;
using UnityEngine.UI;


public class Estadisticas : MonoBehaviour
{
    private int numSaltos = 0;
    private int numDash = 0;
    private int numGanchos = 0;
    private int numEnemigosDerrotados = 0;
    private int numMuertes = 0;
    public float tiempoJugado = 0;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("saltos")) PlayerPrefs.SetInt("saltos", 0);
        else PlayerPrefs.GetInt("saltos", numSaltos);

        if (PlayerPrefs.HasKey("dash")) PlayerPrefs.SetInt("dash", 0);
        else PlayerPrefs.GetInt("dash", numDash);

        if (PlayerPrefs.HasKey("ganchos")) PlayerPrefs.SetInt("ganchos", 0);
        else PlayerPrefs.GetInt("ganchos", numGanchos);

        if (PlayerPrefs.HasKey("enemigos")) PlayerPrefs.SetInt("enemigos", 0);
        else PlayerPrefs.GetInt("enemigos", numEnemigosDerrotados);

        if (PlayerPrefs.HasKey("muertes")) PlayerPrefs.SetInt("muertes", 0);
        else PlayerPrefs.GetInt("muertes", numMuertes);

        if (PlayerPrefs.HasKey("tiempo")) PlayerPrefs.SetFloat("tiempo", 0);
        else PlayerPrefs.GetFloat("tiempo", tiempoJugado);
    }

    public void Salto()
    {
        numSaltos++;
    }

    public void Dash()
    {
        numDash++;
    }

    public void Gancho()
    {
        numGanchos++;
    }

    public void Muerte()
    {
        numMuertes++;
    }

    public void Enemigo()
    {
        numEnemigosDerrotados++;
    }

    public Text saltos;
    private void Update()
    {
        //saltos.text = ""+ numSaltos;
    }

    public void Guardar()
    {
        PlayerPrefs.SetInt("saltos", numSaltos);
        PlayerPrefs.SetInt("dash", numDash);
        PlayerPrefs.SetInt("ganchos", numGanchos);
        PlayerPrefs.SetInt("enemigos", numEnemigosDerrotados);
        PlayerPrefs.SetInt("muertes", numMuertes);
        PlayerPrefs.SetFloat("tiempo", tiempoJugado);

        PlayerPrefs.Save();
    }

    private void OnApplicationQuit()
    {
        Guardar();
    }
}
