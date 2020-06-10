using UnityEngine;

//Script que se encarga de activar el boton Nivel 2 al presionar Jugar en el menu

public class ActivarNivel2Menu : MonoBehaviour
{
    public void ActivarNivel2()
    {
        if (!LevelManager.instance.Nivel2()) gameObject.SetActive(false);
        else gameObject.SetActive(true);
    }
}