using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaJumpthrough : MonoBehaviour
{
    //Collider2D col;
    Collider2D colTrigger;
    void Start()
    {
        //col = GetComponents<Collider2D>()[0];
        //col.isTrigger = false;
        //col.enabled = false;
        colTrigger = GetComponent<Collider2D>();
        //colTrigger.isTrigger = true;
        //colTrigger.enabled = true;
    }

    //void Update()
    //{
    //    Debug.Log(colTrigger.bounds.extents.y);
    //}
    private void OnTriggerExit2D(Collider2D collision)
    {
        Bounds borde = colTrigger.bounds;
        if (collision.gameObject.transform.position.y > transform.position.y + borde.extents.y)
        {
            //col.enabled = true;
            colTrigger.isTrigger = false;
        }
    }
}
