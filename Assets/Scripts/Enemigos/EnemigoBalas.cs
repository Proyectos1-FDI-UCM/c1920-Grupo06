using UnityEngine;

public class EnemigoBalas : MonoBehaviour
{
    bool visible = false, control = false;
    [SerializeField] GameObject balas = null;
    [SerializeField] Transform player = null;
    [SerializeField] float velocidad = 10f, cadencia = 2f;
    GameObject balasprefab;
    Vector3 dirbalas, enemypos;
    float tiempo;

    void Start()
    {
        //posición del enemigo
        enemypos = transform.position;
    }

    private void OnEnable()
    {
        tiempo = Time.time;
    }
    private void Update()
    {
        //dirección de las balas
        dirbalas = player.position - enemypos;
        if (visible)
        {
            if (!control)
            {
                tiempo = Time.time;
                balasprefab = Instantiate(balas, enemypos, transform.rotation);
                balasprefab.transform.SetParent(transform);
                balasprefab.GetComponent<Rigidbody2D>().velocity = dirbalas.normalized * velocidad;
                control = true;
            }
            if (Time.time >= tiempo + cadencia)
            {
                control = false;
                tiempo = Time.time;
            }
        }
    }
    private void OnBecameVisible()
    {
        visible = true;
    }
    private void OnBecameInvisible()
    {
        visible = false;
    }
}
