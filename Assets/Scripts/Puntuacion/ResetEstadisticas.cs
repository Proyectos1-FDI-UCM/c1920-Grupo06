using UnityEngine;

//Script que se encrga de actualizar las estadisticas al resetear

public class ResetEstadisticas : MonoBehaviour
{
    PantallaEstadisticas pantallaEstadisticas = null;

    private void Start()
    {
        pantallaEstadisticas = GetComponent<PantallaEstadisticas>();
    }

    public void ResetTextoEstadisticas()
    {
        PlayerPrefs.SetInt("saltos", 0);
        PlayerPrefs.SetInt("dash", 0);
        PlayerPrefs.SetInt("ganchos", 0);
        PlayerPrefs.SetInt("enemigos", 0);
        PlayerPrefs.SetInt("muertes", 0);
        PlayerPrefs.SetFloat("tiempo", 0);

        pantallaEstadisticas.UpdateText();
        Estadisticas.instance.ResetEstadisticas();
    }
}
