using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroy : MonoBehaviour
{
	private int health=3;

    public AudioClip shock;

	public void DoorDamage(int damageAmount)
	{

		health -= damageAmount;

		if (health <= 0)
		{
			Destroy(gameObject);
		}
		else if (health > 0)
		{
            //ouch noise
        
            AudioSource.PlayClipAtPoint(shock, transform.position,100f);


        }
    }

}




