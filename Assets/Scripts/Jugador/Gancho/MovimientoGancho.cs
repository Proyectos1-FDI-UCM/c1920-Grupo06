﻿using UnityEngine;

//Moviemiento del jugador al usar el gancho

public class MovimientoGancho : MonoBehaviour
{
    [SerializeField] [Range(1, 100)] float velocidad_movimientoGancho = 10; //velocidad del movimiento
    [SerializeField] ParticleSystem particulas_salto = null; //Particulas para cuando el jugador use el gancho en el suelo
    [SerializeField] ParticleSystem particulas_gancho = null; //Particulas para cuando el jugador use el gancho en el aire
    //referencias a componentes del jugador
    Estados estadoJugador = null;
    Rigidbody2D rb = null;
    GameObject gancho;
    Jugador jugador = null;
    Impulso impulso = null;
    Vector3 direccion = Vector3.zero; //direccion del movimiento
    Suelo suelo;

    void Awake()
    {
        //inicializamos las referencias
        rb = GetComponent<Rigidbody2D>();
        jugador = GetComponent<Jugador>();
        estadoJugador = GetComponent<Estados>();
        impulso = GetComponent<Impulso>();
        enabled = false; //lo desactivamos si estuviese activo
        suelo = GetComponentInChildren<Suelo>(); //Los pies deben ser el primer hijo del jugador
    }

    void OnEnable() //al activarse
    {
        //calculamos la direccion del movimiento
        if (suelo.EnSuelo()) particulas_salto.Play();
        else particulas_gancho.Play();
        gancho = jugador.Gancho();
        direccion = gancho.transform.position - transform.position;
        jugador.DireccionImpulso(direccion); //se guarda la dirección para ser usada por el impulso
        rb.velocity = direccion.normalized * velocidad_movimientoGancho; //asignamos la velocidad
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump")) //si se pulsa la tecla de salto, se llama a impulso
            Impulso();
        if ((gancho.transform.position - transform.position).magnitude > direccion.magnitude) Impulso();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (enabled) //si colisiona al estar activo
        {
            Impulso(); //activamos el impulso
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (enabled) //si está activo
        {
            if (collision.gameObject.layer == 14) //si el jugador entra en un trigger que es a la vez un enganche
            {
                Destroy(gancho); //destruimos el gancho
                jugador.DireccionImpulso(Vector3.up); //hacemos un impulso vertical
                estadoJugador.CambioEstado(estado.Defecto); //establecemos el estado a defecto
                impulso.ImpulsoGancho(); //activamos el impulso
            }
        }
    }

    void Impulso() //método para establecer el impulso
    {
        Destroy(gancho); //destruimos el gancho
        estadoJugador.CambioEstado(estado.Defecto); //se cambia el estado a defecto
        impulso.ImpulsoGancho(); //activamos el impulso
    }

    void CambiaEstadoRetardado()
    {
        estadoJugador.CambioEstado(estado.Defecto); //establecemos el estado a defecto ; 
    }
}
