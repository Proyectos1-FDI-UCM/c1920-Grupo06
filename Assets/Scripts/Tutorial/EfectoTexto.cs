using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EfectoTexto : MonoBehaviour
{
    [SerializeField] float tiempoEntreLetras = 0.2f;
    string instruccion = null;
    char letraMensaje;
    Text mensaje;

    public void EfectoLetrasTexto(Text texto)
    {
        mensaje = texto;
        instruccion = mensaje.text;
        mensaje.text = "";
        StartCoroutine(SumarLetras());
        //foreach (char letra in instruccion)
        //{
        //    letraMensaje = letra;
        //    Invoke("SumarLetras", tiempoEntreLetras);
        //}
    }

    private IEnumerator SumarLetras()
    {
        foreach (char letra in instruccion)
        {
            mensaje.text += letra;
            yield return new WaitForSeconds(tiempoEntreLetras);
        }

        //yield return new WaitForSeconds(1.5f);

        //dialogueBubble.SetActive(false);

        //isTalking = false;
    }
}
