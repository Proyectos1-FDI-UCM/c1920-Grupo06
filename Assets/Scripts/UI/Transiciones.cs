using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transiciones : MonoBehaviour
{
    static public Transiciones instance = null;
    Animator transitions = null;
    bool noRepetir = true;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }
    void Start()
    {
        transitions = GetComponentInChildren<Animator>();
    }

    public void MakeTransition(int indice)
    {
        if (noRepetir)
        {
            noRepetir = false;
            StartCoroutine(Transicion(indice));
        }
    }

    private IEnumerator Transicion(int indice)
    {
        transitions.SetTrigger("Salida");
        yield return new WaitForSeconds(0.9f);
        noRepetir = true;
        SceneManager.LoadScene(indice);
    }
}
