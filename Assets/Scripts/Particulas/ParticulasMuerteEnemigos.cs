using UnityEngine;

public class ParticulasMuerteEnemigos : MonoBehaviour
{
    [SerializeField] GameObject particulasGO = null;
    [SerializeField] Color color = Color.white;
    GameObject particula;

    ParticleSystem.MainModule main;

    public void Activar()
    {
        if (particulasGO != null)
        {
            particula = Instantiate(particulasGO, transform.position, Quaternion.identity);

            main = particula.GetComponent<ParticleSystem>().main;
            main.startColor = color;
            Destroy(particula, main.startLifetime.constant);
        }
    }
}