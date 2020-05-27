using UnityEngine;
using UnityEngine.SceneManagement;

//Script del scroll de créditos

public class Scroll : MonoBehaviour
{
    [SerializeField] Transform puntoAIr = null;
    [SerializeField] float velocidad = 2f;
    bool yaInvocado = false;

    void Update()
    {
        //se mueve a un punto
        if (transform.position.y > puntoAIr.position.y)
            transform.position = Vector3.MoveTowards(transform.position, puntoAIr.position, velocidad * Time.deltaTime);
        else if (!yaInvocado) PararCinematico();
    }

    //metodo para parar durante un periodo de tiempo la camara
    private void PararCinematico()
    {
        yaInvocado = true;
        if (SceneManager.GetActiveScene().name == "Creditos") Transiciones.instance.MakeTransition(0);
    }
}
