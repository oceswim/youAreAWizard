/*
 * Oceane Peretti - K1844498 - 3D Games programming Assignment 2
 * I confirm that this project is a product of my own and not the one of someone else.
 */
using UnityEngine;

public class handleWin : MonoBehaviour
{
    // Start is called before the first frame update
   public void YouWon()
	{
        GameManager.instance.WonThisGame();
	}
}
