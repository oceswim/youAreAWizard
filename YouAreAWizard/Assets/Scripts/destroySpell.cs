/*
 * Oceane Peretti - K1844498 - 3D Games programming Assignment 2
 * I confirm that this project is a product of my own and not the one of someone else.
 */
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
