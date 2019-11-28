using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroySpell : MonoBehaviour
{
    public AudioSource shield;
   void OnCollisionEnter(Collision other)
	{
        if(other.transform.CompareTag("PlayerAttack"))
		{
			Destroy(other.gameObject);
            shield.Play();
		}
	}
  
}
