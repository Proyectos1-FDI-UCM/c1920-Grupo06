using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transiciones : MonoBehaviour
{
    static public Transiciones instance = null;
    Animator transitions = null;
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
        StartCoroutine(Transicion(indice));
    }
    private IEnumerator Transicion(int indice)
    {
        transitions.SetTrigger("Salida");
        yield return new WaitForSeconds(0.9f);
        SceneManager.LoadScene(indice);
    }
}
