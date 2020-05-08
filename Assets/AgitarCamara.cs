using UnityEngine;

//Script que agita la cámara cuando el jugador recibe daño

public class AgitarCamara : MonoBehaviour
{

	Vector3 PosIni;  //posición inicial de la cámara
	[SerializeField] float distancia = 0.05f, tiempoHastaDetenerse = 0.5f;
	Camera Camara;

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
		if(Camara != null) Camara.transform.position = PosIni; //se devuelve la cámara a su posición inicial
		//una vez terminado el efecto visual de daño, si el jugador tiene sus vidas a 0, se muere
		if (GameManager.instance != null && GameManager.instance.getVidas() <= 0) GameManager.instance.Muerte();
	}
}
