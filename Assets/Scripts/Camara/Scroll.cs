using UnityEngine;
using UnityEngine.SceneManagement;

//Script del scroll de créditos

public class Scroll : MonoBehaviour
{
    [SerializeField] Transform puntoAIr = null;
    [SerializeField] float velocidad = 2.5f;
    bool yaInvocado = false;

    void Update()
    {
        if (transform.position.y > puntoAIr.position.y)
            transform.position = Vector3.MoveTowards(transform.position, puntoAIr.position, velocidad * Time.deltaTime);
        else if (!yaInvocado) Invoke("PararCinematico", 3f);
    }

    private void PararCinematico()
    {
        yaInvocado = true;
        if (SceneManager.GetActiveScene().name == "Creditos") GameManager.instance.ChangeScene(0);
    }
}
