﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

//Script que se encarga de cambiar los estados dentro del propio tutorial

public class EstadosTutorial : MonoBehaviour
{
    public enum estadoTutorial { primeraSecc, segundaSecc, terceraSecc, cuartaSecc };

    [SerializeField] GameObject button = null, enemigo = null;
    [SerializeField] Estados estados = null;
    [SerializeField] AudioMixer mixer = null;
    //referencia al jugador (y su rigidBody), a los pies, y a todos los powerups
    GameObject jugador = null;
    Rigidbody2D rb = null;
    Suelo pies = null;
    Escudo escudo = null;
    AlargaGancho alargaGancho = null;
    PlataformaNube nube = null;
    SaltoPotenciado botasSalto = null;

    //estados del tutorial, booleanos de control de transiciones
    estadoTutorial estadoTuto;
    bool space, aButton, dButton, rightClick, leftClick, wButton, eButton, ganchoAct, botasAct;

    void Start()
    {
        //obtenemos las referencias
        jugador = estados.gameObject;
        pies = jugador.GetComponentInChildren<Suelo>();
        rb = jugador.GetComponent<Rigidbody2D>();
        escudo = jugador.GetComponent<Escudo>();
        alargaGancho = jugador.GetComponent<AlargaGancho>();
        nube = jugador.GetComponent<PlataformaNube>();
        botasSalto = jugador.GetComponent<SaltoPotenciado>();

        //iniciamos los estados y desactivamos el boton de continuar
        estadoTuto = estadoTutorial.primeraSecc;
        button.SetActive(false);
    }

    void Update()
    {
        ComprobacionesTeclas();
    }

    void ComprobacionesTeclas() //metodo que hace las comprobaciones para saber si se puede pasar a la siguiente fase (hehe)
    {
        switch (estadoTuto)
        {
            case estadoTutorial.primeraSecc:
                {
                    if (Input.GetKeyDown(KeyCode.Space)) space = true;
                    else if (Input.GetKeyDown(KeyCode.A)) aButton = true;
                    else if (Input.GetKeyDown(KeyCode.D)) dButton = true;

                    if (space && aButton && dButton && rb.velocity.magnitude == 0 && pies.EnSuelo())
                        ActivarBoton();
                }
                break;
            case estadoTutorial.segundaSecc:
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0)) leftClick = true;
                    else if (Input.GetKeyDown(KeyCode.Mouse1)) rightClick = true;

                    if (leftClick && rightClick && jugador.transform.position.y > 35f && pies.EnSuelo())
                        ActivarBoton();
                }
                break;
            case estadoTutorial.terceraSecc:
                {
                    if (Input.GetKeyDown(KeyCode.W) && escudo.enabled) wButton = true;
                    else if (Input.GetKeyDown(KeyCode.Q) && nube.enabled) eButton = true;
                    else if (alargaGancho.enabled) ganchoAct = true;
                    else if (botasSalto.enabled) botasAct = true;

                    if (wButton && eButton && ganchoAct && botasAct && pies.EnSuelo())
                        ActivarBoton();
                }
                break;
            case estadoTutorial.cuartaSecc:
                {
                    if ((!enemigo.activeSelf || GameManager.instance.getVidas() == 1) && pies.EnSuelo())
                        ActivarBoton();
                }
                break;
        }
    }

    public void CambioEstado() //metodo que hace los cambios de estado
    {
        switch (estadoTuto) //cambio de estado
        {
            case estadoTutorial.primeraSecc:
                estadoTuto = estadoTutorial.segundaSecc;
                break;
            case estadoTutorial.segundaSecc:
                estadoTuto = estadoTutorial.terceraSecc;
                break;
            case estadoTutorial.terceraSecc:
                estadoTuto = estadoTutorial.cuartaSecc;
                //desactivamos powerups (por si acaso estan activados)
                escudo.enabled = false;
                botasSalto.enabled = false;
                alargaGancho.enabled = false;
                //reactivamos efectos de sonido
                mixer.SetFloat("volumenEfectos_", 0);
                break;
        }
    }

    void ActivarBoton() //metodo para activar el boton
    {
        //activamos boton
        button.SetActive(true);
        rb.velocity = Vector2.zero; //cambiamos su velocidad a 0
        estados.CambioEstado(estado.Inactivo); //ponemos estado inactivo

        if (estadoTuto == estadoTutorial.terceraSecc) mixer.SetFloat("volumenEfectos_", -80f); //silenciamos los efectos

        if (estadoTuto == estadoTutorial.cuartaSecc) //en caso de ser el último
        {
            //cambiamos texto
            button.GetComponentInChildren<Text>().text = "NIVEL 1 >>";
            //paramos al enemigo
            enemigo.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
