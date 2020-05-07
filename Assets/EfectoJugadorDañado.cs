using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectoJugadorDañado : MonoBehaviour
{
    [SerializeField] Color ColorA = Color.red;
    [SerializeField] Color ColorB = Color.green;
    [SerializeField] Color ColorIni;
    [SerializeField] float speed = 1.0f;
    float tiempoInvulnerable = 3f;

    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        enabled = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        ColorIni = spriteRenderer.color;
    }

    void Update()
    {
        spriteRenderer.color = Color.Lerp(ColorA, ColorB, Mathf.PingPong(Time.time * speed, 1.0f));
    }

    public void SetTiempoInvulnerable(float tiempo)
    {
        tiempoInvulnerable = tiempo;
    }

    private void OnDisable()
    {
        if (spriteRenderer != null) spriteRenderer.color = ColorIni;
    }
}
