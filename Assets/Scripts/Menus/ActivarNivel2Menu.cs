using UnityEngine;

public class ActivarNivel2Menu : MonoBehaviour
{
    public void ActivarNivel2()
    {
        if (!LevelManager.instance.Nivel2()) gameObject.SetActive(false);
        else gameObject.SetActive(true);
    }
}
