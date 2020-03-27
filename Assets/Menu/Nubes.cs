using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nubes : MonoBehaviour
{
    float y = 0;
    private void Update()
    {
        y = Mathf.PingPong(Time.time / 20, .1f);
        transform.position = new Vector2(transform.position.x, y);
    }
}
