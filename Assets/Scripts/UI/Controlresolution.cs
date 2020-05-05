using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controlresolution : MonoBehaviour
{
    CanvasScaler cv;

    // Start is called before the first frame update
    void Start()
    {
        cv = this.GetComponent<CanvasScaler>();

    }

    void UpdateResolution()
    {
        float aspect = Camera.main.aspect;

        float rounded = (int)(aspect * 100.0f) / 100.0f;

        if (rounded == 1.65f || rounded == 1.66f || rounded == 1.57f)
            Addrations(0, 5.34f);
        else if (rounded == 2.04f || rounded == 2.05f || rounded == 2.06f)
            Addrations(0.88f, 4.86f);
        else if (rounded == 1.70f || rounded == 1.71f || rounded == 1.69f)
            Addrations(0, 5.21f);
        else if (rounded == 1.33f || rounded == 1.32f || rounded == 1.34f)
            Addrations(0, 6.77f);
        else
            Addrations(0, 5);
    }
    
    void Addrations(float m, float sz)
    {
        if (cv != null)
            cv.matchWidthOrHeight = m;

        Camera.main.orthographicSize = sz;
    }
}
