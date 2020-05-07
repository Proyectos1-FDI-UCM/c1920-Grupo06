using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particulas : MonoBehaviour
{
    ParticleSystemRenderer particulas;
    void Start()
    {
        particulas = GetComponent<ParticleSystemRenderer>();

        particulas.sortingLayerName = "Gancho";
    }
}
