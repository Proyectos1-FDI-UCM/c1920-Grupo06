using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

//Control del comportamiento del menú de ajustes

public class Ajustes : MonoBehaviour
{
    //mix del audio
    [SerializeField] AudioMixer audioMixer = null;

    public void SetVolumenMaster(float volumen) //metodo para establecer el volumen del audio desde el menú de pausa
    {
        audioMixer.SetFloat("volumenMaster_", volumen);
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
}
