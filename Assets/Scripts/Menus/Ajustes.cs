using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Ajustes : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] TMPro.TMP_Dropdown resolutionDropDown;

    Resolution[] resoluciones;

    private void Start()
    {
        resoluciones = Screen.resolutions;
        resolutionDropDown.ClearOptions();
        List<string> opciones = new List<string>();

        for (int i = resoluciones.Length - 1; i >= 0; i--)
        {
            string opcion = resoluciones[i].width + "x" + resoluciones[i].height;
            opciones.Add(opcion);
        }
        resolutionDropDown.AddOptions(opciones);

    }
    public void SetVolumenGeneral(float volumen)
    {
        audioMixer.SetFloat("volumenGeneral_", volumen);
    }
    public void SetVolumenEfectos(float volumen)
    {
        audioMixer.SetFloat("volumenEfectos_", volumen);
    }

    public void SetPantallaCompleta(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolucion(int indice)
    {
        Resolution resolucion = resoluciones[indice];
        Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);
    }

}
