using UnityEngine;

//script que se encarga de aplicar knockback

public class KnockBack : MonoBehaviour
{
    [SerializeField]
    float fuerzaVertical = 1;

    Estados estados;
    Rigidbody2D rb;
    Jugador jug;

    private void Start()
    {
        estados = GetComponent<Estados>();
        rb = GetComponent<Rigidbody2D>();
        jug = GetComponent<Jugador>();
    }

    public void Knockback(Vector3 posObstaculo)
    {
        estados.CambioEstado(estado.Knockback);
        float dirx = Metodos.Vector3toVector2(posObstaculo - transform.position).normalized.x;
        Vector2 dir = new Vector2(-dirx * 2, Vector2.up.y * fuerzaVertical);
        rb.velocity = Vector2.zero;
        rb.AddForce(dir * 10, ForceMode2D.Impulse); //se aplica la fuerza del salto       
        Invoke("ReiniciaEstado", 0.3f);
        jug.RecargaSuelo();
    }

    void ReiniciaEstado()
    {
        rb.velocity = Vector2.zero;
        estados.CambioEstado(estado.Defecto);
    }
}
