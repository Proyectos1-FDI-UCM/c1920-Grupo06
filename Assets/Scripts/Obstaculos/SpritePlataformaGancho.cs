using UnityEngine;

//Script que se encarga de gestionar que sprite asignar a la plataforma ganche

public class SpritePlataformaGancho : MonoBehaviour
{
    [SerializeField] Sprite enganche = null, plataformaGanchoIzq = null, plataformaGanchoDer= null;
    [SerializeField] bool platGanchoIzq = false;

    void Awake()
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (transform.localScale.y == 1) spriteRenderer.sprite = enganche;
        else
        {
            transform.localScale = new Vector2(transform.localScale.x * 1.5f, transform.localScale.y);
            BoxCollider2D box = gameObject.GetComponent<BoxCollider2D>();
            box.size = new Vector2(box.size.x * 0.5f, box.size.y);
            if (platGanchoIzq) spriteRenderer.sprite = plataformaGanchoIzq;
            else spriteRenderer.sprite = plataformaGanchoDer;
        }
    }
}
