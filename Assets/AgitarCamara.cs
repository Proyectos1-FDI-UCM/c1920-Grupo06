using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgitarCamara : MonoBehaviour
{

	Vector3 PosIni;
	public float distancia = 0.05f, tiempoHastaDetenerse = 0.5f;
	Camera Camara;

	private void Awake()
	{
		enabled = false;
	}

	private void OnEnable()
	{
		Camara = Camera.main;
		PosIni = Camara.transform.position;
		InvokeRepeating("ComienzaAgitarCamara", 0f, 0.005f);
		Invoke("PararAgitarCamara", tiempoHastaDetenerse);
	}

	void ComienzaAgitarCamara()
	{
		float cameraShakingOffsetX = Random.value * distancia * 2 - distancia;
		Vector3 cameraIntermadiatePosition = Camara.transform.position;
		cameraIntermadiatePosition.x += cameraShakingOffsetX;
		Camara.transform.position = cameraIntermadiatePosition;
	}

	void PararAgitarCamara()
	{
		CancelInvoke("ComienzaAgitarCamara");
		enabled = false;
	}

	private void OnDisable()
	{
		if(Camara != null) Camara.transform.position = PosIni;
		if (GameManager.instance.getVidas() <= 0) GameManager.instance.Muerte();
	}
}
