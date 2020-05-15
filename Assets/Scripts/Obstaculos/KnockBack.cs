using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    [SerializeField]
    float fuerzaHorizontal = 2, fuerzaVertical = 1;

    estado estadoOri;
    Estados estados;
    Rigidbody2D rb;
    Salto salto;

    private void Start()
    {
        estados = GetComponent<Estados>();
        rb = GetComponent<Rigidbody2D>();
        salto = GetComponent<Salto>();
    }

    public void Knockback(Vector3 posObstaculo)
    {
        estadoOri = estados.Estado();
        estados.CambioEstado(estado.Knockback);
        float dirx = Metodos.Vector3toVector2(posObstaculo - transform.position).normalized.x;
        Vector2 dir = new Vector2(-dirx * 2, Vector2.up.y * fuerzaVertical);
        rb.AddForce(dir * 10, ForceMode2D.Impulse); //se aplica la fuerza del salto
        Invoke("ReiniciaEstado", 0.3f);
    }

    void ReiniciaEstado()
    {
        estados.CambioEstado(estadoOri);
    }
}
