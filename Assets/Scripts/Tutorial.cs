using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] Transform jugador = null, seccion2 = null, seccion3 = null, seccion4 = null;
    bool seccion2Esta = false, seccion3Esta = false;

    public void Continuar()
    {
        AsignacionTransform();
        Camera.main.transform.position = new Vector3(jugador.position.x, jugador.position.y + 4, Camera.main.transform.position.z);
    }

    private void AsignacionTransform()
    {
        if (seccion2Esta)
        {
            if (seccion3Esta) jugador.transform.position = seccion4.transform.position;
            else
            {
                jugador.transform.position = seccion3.transform.position;
                seccion3Esta = true;
            }
        }
        else
        {
            jugador.transform.position = seccion2.transform.position;
            seccion2Esta = true;
        }
    }
}
