/*
 * Oceane Peretti - K1844498 - 3D Games programming Assignment 2
 * I confirm that this project is a product of my own and not the one of someone else.
 */
using UnityEngine;

public class PlayerDestroy : MonoBehaviour
{
    private int health;
    public AudioClip gateImpact,stoneImpact,gateDestroy,StoneDestroy;
    private GameObject thePlayer;
    private void Start()
    {
        thePlayer = GameObject.Find("Player");
        if (gameObject.name == "destroyGate")
        {
            health = 3;
        }
        else if (gameObject.tag == "magicStone")
        {
            health = 2;
            //add point to player
        }
    }
    public void theDamage(int damageAmount)
	{

		health -= damageAmount;

		if (health <= 0)
		{
            if (gameObject.name == "destroyGate")
            {
                AudioSource.PlayClipAtPoint(gateDestroy, thePlayer.transform.position, 200f);

            }
            else if (gameObject.tag == "magicStone")
            {
                AudioSource.PlayClipAtPoint(StoneDestroy, thePlayer.transform.position, 200f);
                Player.regenerate= true;

            }
            Destroy(gameObject);
        }
		else if (health > 0)
		{
            if (gameObject.name == "destroyGate")
            {
                AudioSource.PlayClipAtPoint(gateImpact, thePlayer.transform.position, 200f);
            }
            else if (gameObject.tag == "magicStone")
            {
                AudioSource.PlayClipAtPoint(stoneImpact, thePlayer.transform.position, 200f);


            }


        }
    }

}




