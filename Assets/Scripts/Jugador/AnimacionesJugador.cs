using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionesJugador : MonoBehaviour
{
    Animator animador;
    Rigidbody2D rb;
    Suelo suelo;
    Estados estadoJugador;
    [SerializeField] float delta = 0.05f;
    bool enSuelo = false;
    bool enSueloAux = false;

    int velx = 0;
    int velxaux = 0;
    private void Start()
    {
        //Inicializamos los componentes
        animador = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        suelo = GetComponentInChildren<Suelo>();
        estadoJugador = GetComponent<Estados>();
    }
    private void Update()
    {
        enSuelo = suelo.EnSuelo();
        if (enSuelo != enSueloAux)
        {
            CambioAnimacion(estadoJugador.Estado());
            enSueloAux = enSuelo;
        }
        if (enSuelo)
        {
            float velocidad = rb.velocity.x;
            if (velocidad < -delta) velx = 0;
            else if (velocidad > delta) velx = 2;
            else velx = 1;
            if(velx != velxaux)
            {
                CambioAnimacion((estadoJugador.Estado()));
                velxaux = velx;
            }
        }
    }
    public void CambioAnimacion(estado estadoActual)
    {
        switch (estadoActual)
        {
            case estado.Defecto:
                float velocidad = rb.velocity.x;
                if (!enSuelo)
                    animador.Play("Caida");
                else if (velocidad < -delta)
                    animador.Play("MovimientoInvertido");
                else if (velocidad > delta)
                    animador.Play("Movimiento");
                else animador.Play("Iddle");
                break;
            default:
                animador.Play("Caida");
                break;
        }
    }

}
