using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEventWaveScene : MonoBehaviour
{
	public GameObject toActivate;
	public GameObject toDeActivate;

	private void Update()
	{

	}
	void OnTriggerEnter(Collider other)
	{

		toActivate.SetActive(true);
		Destroy(toDeActivate);
        Destroy(gameObject);//destroy the teleport area

	}
	
}
