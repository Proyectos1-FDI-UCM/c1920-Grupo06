using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

//Control del comportamiento del menú de ajustes

public class Ajustes : MonoBehaviour
{
    //mix del audio y dropdown de resoluciones
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] TMPro.TMP_Dropdown resolutionDropDown;
    Resolution[] resoluciones;

    void Start()
    {
        //guardamos todas las resoluciones
        resoluciones = Screen.resolutions;
        //vaciamos las opciones del dropdown
        resolutionDropDown.ClearOptions();
        ////creamos la lista de resoluciones
        List<string> opciones = new List<string>();

        
        opciones.Add("1920x1080");
        //opciones.Add("1280x720");

        //las establecemos como opciones del dropdown
        resolutionDropDown.AddOptions(opciones);


    }

    public void SetVolumenGeneral(float volumen) //metodo para establecer el volumen del audio desde el menú de pausa
    {
        audioMixer.SetFloat("volumenMusica_", volumen);
    }

    public void SetVolumenEfectos(float volumen) //metodo para establecer el volumen de los efectos desde el menu de pausa
    {
        audioMixer.SetFloat("volumenEfectos_", volumen);
    }

    public void SetPantallaCompleta(bool isFullscreen) //metodo para establecer la pantalla completa desde el editor
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolucion(int indice) //metodo para cambiar la resoluciondesde el menú
    {
        //Resolution resolucion = resoluciones[indice]; //obtenemos el índice de la resolucion
        //Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen); //la establecemos
        for (int i = 0; i < resoluciones.Length; i++) //guardamos las disponibles en el ordenador
        {
            string opcion = resoluciones[i].width + "x" + resoluciones[i].height;
            if (opcion == resolutionDropDown.options[indice].text)
            {
                Screen.SetResolution(resoluciones[i].width, resoluciones[i].height, Screen.fullScreen); //la establecemos
            }
        }
    }

}
