using UnityEngine;

//Comportamiento del PowerUp "Nube"

public class PlataformaNube : MonoBehaviour
{
    [SerializeField] float distanciaPlataforma = 1; //distancia de aparición de la nube
    [SerializeField] GameObject plataforma = null; //prefab de la nube

    void Awake()
    {
        enabled = false; //desactivamos en caso de estar activado en editor
    }

    void OnEnable() //cuando se active el PowerUp
    {
        GameManager.instance.ActivaSprite(0); //activamos su referencia en la interfaz
    }

    void Update()
    {
        if (Input.GetButtonDown("PowerUp1")) //cuando se presione su botón asignado
        {
            //instanciamos la nube
            Instantiate(plataforma, new Vector3(transform.position.x, transform.position.y - distanciaPlataforma, 0), Quaternion.identity);
            enabled = false; //desactivamos el PowerUp
        }
    }

    void OnDisable() //al desactivarse el PowerUp
    {
        GameManager.instance.DesactivaSprite(0); //desactivamos su referencia en la interfaz
    }
}
