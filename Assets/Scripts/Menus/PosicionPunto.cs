using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosicionPunto : MonoBehaviour
{
    [SerializeField] Transform punto;
    void Start()
    {
        transform.localPosition = new Vector2(-punto.position.x, punto.position.y);
    }
}
