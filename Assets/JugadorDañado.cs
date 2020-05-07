using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorDañado : MonoBehaviour
{
    public Color A = Color.red;
    public Color B = Color.green;
    public Color C;
    public float speed = 1.0f;
    float tiempoInvulnerable = 3f;

    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        enabled = false;
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        C = spriteRenderer.color;
    }

    void Update()
    {
        spriteRenderer.color = Color.Lerp(A, B, Mathf.PingPong(Time.time * speed, 1.0f));
    }

    public void SetTiempoInvulnerable(float tiempo)
    {
        tiempoInvulnerable = tiempo;
    }

    //private void OnDisable()
    //{
    //    spriteRenderer.color = C;
    //}
}
