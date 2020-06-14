﻿using UnityEngine;

//Control de las animaciones y particulas ombatedel jugador

public class AnimacionesJugador : MonoBehaviour
{
    [SerializeField] float delta = 0.3f;
    [SerializeField] ParticleSystem particulas = null;
    [SerializeField] ParticleSystem particulasIzq = null;
    [SerializeField] ParticleSystem particulasDer = null;
    [SerializeField] ParticleSystem particulasDash = null;
    Animator animador;
    Rigidbody2D rb;
    Suelo suelo;
    Estados estadoJugador;
    DeslizamientoPared deslizamiento;
    bool enSuelo = false, enSueloAux = false;
    int velx = 0, velxaux = 0;

    void Start()
    {
        //inicializamos los componentes
        animador = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        suelo = GetComponentInChildren<Suelo>();
        estadoJugador = GetComponent<Estados>();
        deslizamiento = GetComponentInChildren<DeslizamientoPared>();

        Particulas(0);
    }

    void Update()
    {
        //comprobamos si está en el suelo
        enSuelo = suelo.EnSuelo();

        if (enSuelo != enSueloAux) //si no lo estuviera
        {
            //cambiamos su animación con respecto al estado actual del jugador
            CambioAnimacion(estadoJugador.Estado());
            enSueloAux = enSuelo; //establecemos que no se encuentra en el suelo
        }
        if (enSuelo) //si estuviera en el suelo
        {
            //guardamos su velocidad en el eje 'x'
            float velocidad = rb.velocity.x;

            //si la dirección es distinta de en la que ya se encontraba
            if (velx != velxaux)
            {
                //cambiamos la animación con respecto al estado del jugador
                CambioAnimacion(estadoJugador.Estado());
                velxaux = velx; //actualizamos la dirección
            }
        }
        else
        {
            CambioAnimacion(estadoJugador.Estado());
        }
    }

    public void CambioAnimacion(estado estadoActual) //método para cambiar la animación
    {
        switch (estadoActual)
        {
            case estado.Defecto: //de estar sobre una plataforma
                float velocidad = rb.velocity.x;
                float velocidad_y = rb.velocity.y;

                //establecemos la animación con respecto a la velocidad
                if (!enSuelo)
                {
                    if (deslizamiento.GetCollider != posicionColliders.ninguna)
                    {
                        if (deslizamiento.GetCollider == posicionColliders.izquierda) //Delizamiento izquierda
                        {
                            animador.Play("DeslizamientoIzquierda");
                            Particulas(3);
                        }
                        else if (deslizamiento.GetCollider == posicionColliders.derecha)//Deslizamiento derecha
                        {
                            animador.Play("DeslizamientoDerecha");
                            Particulas(2);
                        }
                    }
                    else
                    {
                        if (velocidad_y > delta) //Velocidad de subida
                        {
                            animador.Play("Salto");
                        }
                        else //Velocidad de Bajada
                        {
                            animador.Play("Caida");
                        }
                        Particulas(0);
                    }
                }
                else if (velx == -1)
                {
                    animador.Play("MovimientoInvertido");
                    Particulas(1);
                }
                else if (velx == 1)
                {
                    animador.Play("Movimiento");
                    Particulas(1);
                }
                else
                {
                    animador.Play("Iddle");
                    Particulas(0);
                }
                break;
            case estado.Dash:
                animador.Play("Dash");
                Particulas(4);
                break;
            default: //en caso contrario, ponemos la animación "Caída" por defecto
                animador.Play("Caida");
                Particulas(0);
                break;
        }
    }
    void Particulas(int n) //Metedo que activa y desactiva las partículas
    { //n = 0: ninguna, n = 1: movimiento, n = 2: deslizamiento derecha, n = 3: deslizamiento izquierda, n = 4: dash
        switch (n)
        {
            case 0:
                particulas.Stop();
                particulasDer.Stop();
                particulasIzq.Stop();
                particulasDash.Stop();
                break;
            case 1:
                if (!particulas.isEmitting)
                    particulas.Play();
                particulasDer.Stop();
                particulasIzq.Stop();
                particulasDash.Stop();
                break;
            case 2:
                particulas.Stop();
                if (!particulasDer.isEmitting)
                    particulasDer.Play();
                particulasIzq.Stop();
                particulasDash.Stop();
                break;
            case 3:
                particulas.Stop();
                particulasDer.Stop();
                if (!particulasIzq.isEmitting)
                    particulasIzq.Play();
                particulasDash.Stop();
                break;
            case 4:
                particulas.Stop();
                particulasDer.Stop();
                particulasIzq.Stop();
                if (!particulasDash.isEmitting)
                    particulasDash.Play();
                break;
        }
    }

    public void VelocidadInput(int vel)
    {
        velx = vel;
    }
}
