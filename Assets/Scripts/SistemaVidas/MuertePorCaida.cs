﻿using UnityEngine;

//Comportamiento de la DeathZone (hija de la cámara)

public class MuertePorCaida : MonoBehaviour
{
    [SerializeField]AgitarCamara agitarCamara;
    [SerializeField]EfectoJugadorDañado efectoJugadorDañado;

    void OnTriggerEnter2D(Collider2D collision) //cuando alguna entidad entre al "trigger"
    {
        Estados jugador = collision.gameObject.GetComponent<Estados>(); //comprobamos si es el jugador

        if (jugador != null) //en caso de que lo fuera
        {
            jugador.CambioEstado(estado.Muerte); //cambiamos su estado a Muerte
            agitarCamara.enabled = true;
            GameManager.instance.Muerte();
        }
    }
}
