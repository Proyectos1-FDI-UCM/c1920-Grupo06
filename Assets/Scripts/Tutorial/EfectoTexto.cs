using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EfectoTexto : MonoBehaviour
{
    [SerializeField] float tiempoEntreLetras = 0.2f;
    string instruccion = null;
    Text mensaje;

    public void EfectoLetrasTexto(Text texto)
    {
        mensaje = texto;
        instruccion = mensaje.text;
        mensaje.text = "";
        StartCoroutine(SumarLetras());
    }

    private IEnumerator SumarLetras()
    {
        foreach (char letra in instruccion)
        {
            mensaje.text += letra;
            yield return new WaitForSeconds(tiempoEntreLetras);
        }
    }
}
