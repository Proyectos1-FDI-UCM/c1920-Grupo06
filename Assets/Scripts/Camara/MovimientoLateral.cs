using UnityEngine;

//Script para la transicion lateral de la camara

public class MovimientoLateral : MonoBehaviour
{
    [SerializeField] GameObject puntoLateral = null;

    float posXOri = 0;
    Transform jug = null;
    Transform cam = null;

    private void Start()
    {
        cam = Camera.main.transform;
        posXOri = cam.position.x;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Jugador>() != null)
        {
            jug = collision.GetComponent<Transform>();

            //si el jugador ha salido del trigger por la derecha
            if (jug.position.x > transform.position.x) 
            {
                Vector3 posCam = cam.position;
                posCam.x = puntoLateral.transform.position.x;
                cam.position = posCam;
            }
            //en caso de que lo haga por la izquierda
            else if (jug.position.x < transform.position.x) 
            {
                Vector3 posCam = cam.position;
                posCam.x = posXOri;
                cam.position = posCam;
            }
        }
    }

    private void Update() //en caso de que el jugador muera, al no pasar por ningun trigger, se mueve la camara a su posicion original
    {
        if(jug != null)
        {
            if(jug.position.x < cam.position.x - 20)
            {
                Vector3 pos = cam.position;
                pos.x = posXOri;
                cam.position = pos;
            }
        }
    }
}
