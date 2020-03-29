using UnityEngine;

public class PlataformaNube : MonoBehaviour
{
    [SerializeField] GameObject plataforma = null;
    [SerializeField] float distanciaPlataforma = 1;

    void Awake()
    {
        enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            Instantiate(plataforma, new Vector3(transform.position.x, transform.position.y - distanciaPlataforma, 0), Quaternion.identity);
            enabled = false;
        }
    }
}
