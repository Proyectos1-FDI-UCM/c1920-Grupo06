using UnityEngine;
using UnityEngine.Audio;

public class TransicionesTutorial : MonoBehaviour
{
    [SerializeField] Transform jugador = null, seccion2 = null, seccion3 = null, seccion4 = null;
    [SerializeField] ActivacionTextosTutorial actTexts = null;
    [SerializeField] Estados estados = null;
    [SerializeField] GameObject continuar = null, powerups = null;
    bool seccion2Esta = false, seccion3Esta = false, seccion4Esta = false;

    public void Continuar() //metodo para continuar a la siguiente seccion
    {
        estados.CambioEstado(estado.Defecto);

        if (seccion4Esta) //Si es la ultima lo llevamos al nivel 1
        {
            GameManager.instance.ChangeScene(1);
        }
        else //en caso contrario, cambiamos a la siguiente seccion
        {
            AsignacionTransform();
            Camera.main.transform.position = new Vector3(jugador.position.x, jugador.position.y + 4, Camera.main.transform.position.z);
        }

        Time.timeScale = 1f;
        continuar.SetActive(false);
    }

    private void AsignacionTransform()
    {
        if (seccion2Esta)
        {
            if (seccion3Esta)
            {
                jugador.transform.position = seccion4.transform.position;
                powerups.SetActive(false);
                actTexts.ActivarTextoSeccion4();
                seccion4Esta = true;
            }
            else
            {
                jugador.transform.position = seccion3.transform.position;
                powerups.SetActive(true);
                actTexts.ActivarTextoSeccion3();
                seccion3Esta = true;
            }
        }
        else
        {
            jugador.transform.position = seccion2.transform.position;
            actTexts.ActivarTextoSeccion2();
            seccion2Esta = true;
        }
    }
}
