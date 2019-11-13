using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroy : MonoBehaviour
{
	private int health;

    public AudioClip shock;
    private void Start()
    {
        if (gameObject.name == "DungeonGate")
        {
            health = 3;
        }
        else if (gameObject.tag == "magicStone")
        {
            health = 2;
        }
    }
    public void theDamage(int damageAmount)
	{

		health -= damageAmount;

		if (health <= 0)
		{
            if(gameObject.tag=="magicStone")
            {
                activate.activation = true;//desactive barrier
            }
			Destroy(gameObject);
		}
		else if (health > 0)
		{
         
          AudioSource.PlayClipAtPoint(shock, transform.position, 200f);
            
        }
    }

}




