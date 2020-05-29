using UnityEngine;

public class ParticulasMuerteEnemigos : MonoBehaviour
{
    [SerializeField] GameObject particulasGO = null;
    [SerializeField] Color color = Color.white;


    public void Activar()
    {
        if (particulasGO != null)
        {
            GameObject particula = Instantiate(particulasGO, transform.position, Quaternion.identity);
            ParticleSystem.MainModule main = particula.GetComponent<ParticleSystem>().main;

            main.startColor = color;
            Destroy(particula, main.startLifetime.constant);
        }
    }
}