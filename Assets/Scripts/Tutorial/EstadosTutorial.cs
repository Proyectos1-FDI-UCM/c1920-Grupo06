using UnityEngine;
using UnityEngine.UI;

public class EstadosTutorial : MonoBehaviour
{
    public enum estadoTutorial {primeraSecc, segundaSecc, terceraSecc, cuartaSecc};

    [SerializeField] GameObject button = null;
    [SerializeField] Estados estados = null;
    estadoTutorial estadoTuto;
    bool space, aButton, dButton, rightClick, leftClick, wButton, eButton;

    void Start()
    {
        estadoTuto = estadoTutorial.primeraSecc;
        button.SetActive(false);
    }

    void Update()
    {
        ComprobacionesTeclas();
    }

    void ComprobacionesTeclas()
    {
        switch (estadoTuto)
        {
            case estadoTutorial.primeraSecc:
                if (Input.GetKeyDown(KeyCode.Space)) space = true;
                else if (Input.GetKeyDown(KeyCode.A)) aButton = true;
                else if (Input.GetKeyDown(KeyCode.D)) dButton = true;

                if (space && aButton && dButton) Invoke("ActivarBoton", 0.7f);
                break;
            case estadoTutorial.segundaSecc:
                break;
            case estadoTutorial.terceraSecc:
                break;
            case estadoTutorial.cuartaSecc:
                break;
        }
    }

    public void CambioEstado()
    {
        switch (estadoTuto)
        {
            case estadoTutorial.primeraSecc:
                estadoTuto = estadoTutorial.segundaSecc;
                button.SetActive(false);
                break;
            case estadoTutorial.segundaSecc:
                estadoTuto = estadoTutorial.terceraSecc;
                button.SetActive(false);
                break;
            case estadoTutorial.terceraSecc:
                estadoTuto = estadoTutorial.cuartaSecc;
                button.SetActive(false);
                break;
        }
    }

    void ActivarBoton()
    {
        button.SetActive(true);
        if (estadoTuto == estadoTutorial.cuartaSecc) button.GetComponentInChildren<Text>().text = "NIVEL 1";
        estados.CambioEstado(estado.Inactivo);
    }
}
