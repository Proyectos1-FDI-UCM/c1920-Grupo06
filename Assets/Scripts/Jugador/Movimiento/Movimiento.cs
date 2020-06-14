﻿using UnityEngine;

//Comportamiento del movimiento horizontal del jugador, y la velocidad de caída

public class Movimiento : MonoBehaviour
{
    [SerializeField] [Range(15, 25)] float velocidad_movimiento = 20; //velocidad del desplazamiento
    [SerializeField] [Range(-30, 0)] float velocidad_caida_maxima = -20; //velocidad de caída
    Rigidbody2D rb;
    DeslizamientoPared deslizamiento;
    AudioSource aud;
    AnimacionesJugador anim;
    AudioSource[] audAux;
    Suelo suelo;

    private void Awake()
    {
        audAux = GetComponentsInChildren<AudioSource>();
        aud = audAux[Metodos.EncuentraAudioSource(audAux, "Pasos")];
    }

    void Start()
    {
        //inicializamos las referencias
        rb = GetComponent<Rigidbody2D>();
        deslizamiento = GetComponent<DeslizamientoPared>();
        suelo = transform.parent.GetComponentInChildren<Suelo>();
        anim = GetComponent<AnimacionesJugador>();
    }

    void Update()
    {
        //guardamos el valor del input
        float input = Input.GetAxis("Horizontal");

        if (input > 0.2f)
            anim.VelocidadInput(1);
        else if (input < -0.2f)
            anim.VelocidadInput(-1);
        else anim.VelocidadInput(0);

        //establecemos la velocidad
        rb.velocity = new Vector2(input * velocidad_movimiento, rb.velocity.y);

        //reproducimos el sonido de pasos si se está moviendo
        if (rb.velocity.x != 0 && suelo.EnSuelo()) aud.UnPause();
        else aud.Pause();

        //si la velocidad de caida es maypr de la establecida, la reestablecemos a esta
        if (rb.velocity.y < velocidad_caida_maxima)
        {
            Vector2 velocidad = rb.velocity; velocidad.y = velocidad_caida_maxima;
            rb.velocity = velocidad;
        }
    }
}
