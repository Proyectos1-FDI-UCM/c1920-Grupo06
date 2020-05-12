using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//Script encargado de la aparición progresiva de cada letra

public class EfectoTexto : MonoBehaviour
{
    //tiempo de aparicion
    [SerializeField] float tiempoEntreLetras = 0.2f;

    //método publico que permite desde fuera (ActivacionTextosTutorial) ejecute el efecto de aparición de las letras
    public void EfectoLetrasTexto(Text texto)
    {
        //guardamos el componente Text
        Text mensaje = texto;
        //guardamos su texto
        string instruccion = mensaje.text;
        //vaciamos dicho mensaje
        mensaje.text = "";
        //comenzamos una corrutina para la aparición de las letras
        StartCoroutine(SumarLetras(instruccion, mensaje));
    }

    //corrutina de aparición progresiva
    private IEnumerator SumarLetras(string instruccion, Text mensaje)
    {
        foreach (char letra in instruccion) //para cada letra de la instruccion
        {
            mensaje.text += letra; //la añade al componente Text
            //espera 'x' segundos en la ejecución para avanzar a la siguiente
            yield return new WaitForSeconds(tiempoEntreLetras);
        }
    }
}
