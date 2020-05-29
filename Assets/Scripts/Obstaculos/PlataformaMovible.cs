﻿using UnityEngine;

//Comportamiento de la plataforma movible

public class PlataformaMovible : MonoBehaviour
{
    //variables de movimiento
    [Header("Velocidad desplazamiento: ")]
    [SerializeField] float initialSpeed = 5f; //velocidad inicial de la entidad (establece dirección)
    [SerializeField] Transform puntoA = null, puntoB = null; //limites inferior (izquierda, abajo) y superior (derecha, arriba)
    [SerializeField] bool diagonal = false; //booleano que indica si la plataforma se mueve de manera horizontal o vertical
    bool horizontal = false, diagonalInversa = false;
    Transform nextPos;

    float fuerzaSaltoOri = 0f;

    //variables de mantener al jugador en la plataforma
    GameObject jugador;
    Transform padre;
    Estados estados;
    Rigidbody2D rbJugador;
    bool sobrePlataforma = false;

    void OnEnable() //cuando se active (reaparición)
    {
        nextPos = puntoB; //el siguiente punto siempre es B
        if (!diagonal) horizontal = puntoB.position.x != puntoA.position.x; //si no es diagonal, comprobamos si es horizontal o vertical
        else diagonalInversa = puntoB.position.x < puntoA.position.x; //si es diagonal, comprobamos la direccion de dicha diagonal
    }

    void Update()
    {
        Limites(); //comprobamos si se ha salido de los límites

        //movemos a la plataforma al siguiente punto
        transform.position = Vector3.MoveTowards(transform.position, nextPos.position, initialSpeed * Time.deltaTime);
    }

    void Limites()
    {
        if (diagonal)
        {
            if (diagonalInversa)
            {
                //si se ha salido de los límites superiores (esquina arriba)
                if (transform.position.x <= puntoB.transform.position.x && transform.position.y >= puntoB.transform.position.y)
                {
                    transform.position = puntoB.position;
                    nextPos = puntoA;
                }
                //si se ha salido de los límites inferiores (esquina abajo)
                else if (transform.position.x >= puntoA.transform.position.x && transform.position.y <= puntoA.transform.position.y)
                {
                    transform.position = puntoA.position;
                    nextPos = puntoB;
                }
            }
            else
            {
                //si se ha salido de los límites superiores (esquina arriba)
                if (transform.position.x >= puntoB.transform.position.x && transform.position.y >= puntoB.transform.position.y)
                {
                    transform.position = puntoB.position;
                    nextPos = puntoA;
                }
                //si se ha salido de los límites inferiores (esquina abajo)
                else if (transform.position.x <= puntoA.transform.position.x && transform.position.y <= puntoA.transform.position.y)
                {
                    transform.position = puntoA.position;
                    nextPos = puntoB;
                }
            }
        }
        else if (horizontal)
        {
            //si se ha salido de los límites superiores (derecha)
            if (transform.position.x >= puntoB.transform.position.x)
            {
                transform.position = puntoB.position;
                nextPos = puntoA;
            }
            //si se ha salido de los límites inferiores (izquierda)
            else if (transform.position.x <= puntoA.transform.position.x)
            {
                transform.position = puntoA.position;
                nextPos = puntoB;
            }
        }
        else
        {
            //si se ha salido de los límites superiores (arriba)
            if (transform.position.y >= puntoB.transform.position.y)
            {
                transform.position = puntoB.position;
                nextPos = puntoA;
            }
            //si se ha salido de los límites inferiores (abajo)
            else if (transform.position.y <= puntoA.transform.position.y)
            {
                transform.position = puntoA.position;
                nextPos = puntoB;
            }
        }
    }

    //En caso de que el jugador esté encima de la plataforma
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Se comprueba si verdaderamente se ha subido el jugador
        Suelo pies = collision.gameObject.GetComponent<Suelo>();

        if (pies != null)
        {
            Salto salto = collision.transform.parent.GetComponent<Salto>();
            fuerzaSaltoOri = salto.GetFuerzaSalto();
            sobrePlataforma = true;
            jugador = collision.gameObject.transform.parent.gameObject;
            estados = jugador.GetComponent<Estados>();
            rbJugador = jugador.GetComponent<Rigidbody2D>();
            padre = jugador.transform.parent;
        }
    }

    //En caso de que el jugador siga encima de la plataforma
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (sobrePlataforma)
        {
            Salto salto = collision.transform.parent.GetComponent<Salto>();
            if (salto != null && nextPos == puntoB && !horizontal) // solo cambia la fuerza del salto mientras sube
                if (!diagonal)
                    salto.CambiaFuerzaSalto(fuerzaSaltoOri * 1.5f);
                else salto.CambiaFuerzaSalto(fuerzaSaltoOri * 1.15f);

            //Mientras el jugador no esté en medio de otra acción
            if (!(Input.GetButtonDown("Jump") || Input.GetAxis("Horizontal") != 0) && estados.Estado() == estado.Defecto)
            {
                //Se hace hijo de la plataforma
                rbJugador.isKinematic = true;
                jugador.transform.parent = transform;
            }
            else
            {
                //Deja de ser hijo de la plataforma
                rbJugador.isKinematic = false;
                jugador.transform.parent = padre;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Suelo pies = collision.gameObject.GetComponent<Suelo>();

        if (pies != null)
        {
            Salto salto = collision.transform.parent.GetComponent<Salto>();
            salto.CambiaFuerzaSalto(fuerzaSaltoOri);
            rbJugador.isKinematic = false;
            jugador.transform.parent = padre;
            rbJugador = null;
            jugador = null;
            sobrePlataforma = false;
            estados = null;
            padre = null;
        }
    }
}

