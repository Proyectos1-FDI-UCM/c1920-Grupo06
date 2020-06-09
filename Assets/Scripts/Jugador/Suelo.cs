﻿using UnityEngine;

//Comprobación de si el jugador se encuentra sobre una plataforma (trigger "PiesJugador")

public class Suelo : MonoBehaviour
{
    bool enSuelo = false; //booleano que controla si el jugador está o no en el suelo
    Jugador jugador;

    void Start()
    {
        //obtenemos la referencia al script "Jugador"
        jugador = gameObject.GetComponentInParent<Jugador>();
    }

    void OnTriggerStay2D(Collider2D collision) //si está sobre añguna entidad
    {
        BoxCollider2D box = collision.GetComponent<BoxCollider2D>();
        CompositeCollider2D comp = collision.GetComponent<CompositeCollider2D>();

        if (comp != null || (box != null && !box.isTrigger)) //si esa entidad es una plataforma (Layer 8 => plataformas7escenario)
        {
            enSuelo = true; //actualizamos el booleano, pues está sobre alguna entidad
            jugador.RecargaSuelo(); //recargamos el dash y gancho (llamamos a RecargaSuelo de "Jugador")
        }
    }

    void OnTriggerExit2D(Collider2D collision) //cuando deja de estar sobre la plataforma
    {
        enSuelo = false; //lo señalamos con el booleano
    }

    public bool EnSuelo() //método que devuelve si el jugador estña sobre una plataforma o no
    {
        return enSuelo;
    }
}
