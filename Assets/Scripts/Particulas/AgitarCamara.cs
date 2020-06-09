using UnityEngine;

//Script que agita la cámara cuando el jugador recibe daño

public class AgitarCamara : MonoBehaviour
{
	[SerializeField] float distancia = 0.05f, tiempoHastaDetenerse = 0.5f;
	Vector3 PosIni;  //posición inicial de la cámara
	Camera Camara;
	bool jugadorMuerto;

	[SerializeField] AudioSource audDanyado = null, audMuerto = null;

	//empieza desactivado
	private void Awake()
	{
		enabled = false;
	}

	//al activarse, la cámara se agitará durante "tiempoHastaDetenerse" segundos
	private void OnEnable()
	{
		Camara = Camera.main;
		PosIni = Camara.transform.position;
		jugadorMuerto = GameManager.instance != null && GameManager.instance.getVidas() <= 0;
		if (jugadorMuerto) audMuerto.Play();
		else audDanyado.Play();

		InvokeRepeating("ComienzaAgitarCamara", 0f, 0.005f);
		Invoke("PararAgitarCamara", tiempoHastaDetenerse);
	}

	//se cálcula una posición aleatoria en las x
	void ComienzaAgitarCamara()
	{
		float limiteEnX = Random.value * distancia * 2 - distancia;
		Camara.transform.position = new Vector3 (Camara.transform.position.x + limiteEnX, Camara.transform.position.y, Camara.transform.position.z);
	}

	//se termina el movimiento y se desactiva el script
	void PararAgitarCamara()
	{
		CancelInvoke("ComienzaAgitarCamara");
		enabled = false;
	}

	//al desactivarse
	private void OnDisable()
	{
		//se devuelve la cámara a su posición inicial
		if (Camara != null) Camara.transform.position = new Vector3(PosIni.x, Camara.transform.position.y, Camara.transform.position.z);											  
		if (jugadorMuerto) //una vez terminado el efecto visual de daño, si el jugador tiene sus vidas a 0, se muere
		{
			GameManager.instance.Muerte();
		}
	}
}
