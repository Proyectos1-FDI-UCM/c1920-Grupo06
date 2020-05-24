using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticulasMuerteEnemigos : MonoBehaviour
{
    [SerializeField] GameObject enemigo = null;
    ParticleSystem particulas;
    ParticleSystem.MainModule main;
    private void Start()
    {
        particulas = GetComponent<ParticleSystem>();
        main = particulas.main;
    }
    public void Activar(Color color)
    {
        main.startColor = color;
        particulas.transform.position = enemigo.transform.position;
        particulas.Play();
    }
}
