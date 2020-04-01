using UnityEngine;

public class Pausa : MonoBehaviour
{
    Estados estado;
    public Suelo suelo;
    bool pausa;
    void Start()
    {
        estado = gameObject.GetComponent<Estados>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0 && Input.GetButtonDown("Cancel") && estado.Estado() == global::estado.Defecto && suelo.EnSuelo())
        {
            GameManager.instance.Pausa();
            estado.CambioEstado(global::estado.Inactivo);
        }
        else if(Time.timeScale == 0 && Input.GetButtonDown("Cancel"))
        {
            estado.CambioEstado(global::estado.Defecto);
            Input.ResetInputAxes();
            GameManager.instance.QuitarPausa();
        }

    }
}
