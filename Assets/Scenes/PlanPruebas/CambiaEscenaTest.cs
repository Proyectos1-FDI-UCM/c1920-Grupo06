using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiaEscenaTest : MonoBehaviour
{
    public void CambiaEscenaTest_(string nuevaEscena)
    {
        SceneManager.LoadScene(nuevaEscena);
    }
}
