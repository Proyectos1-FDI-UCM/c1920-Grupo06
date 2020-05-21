using UnityEngine;

public class ActivarNivel2Menu : MonoBehaviour
{
    void Awake()
    {
        if (!LevelManager.instance.Nivel2()) gameObject.SetActive(false);
        else gameObject.SetActive(true);
    }
}
