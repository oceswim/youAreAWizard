/*
 * Oceane Peretti - K1844498 - 3D Games programming Assignment 2
 * I confirm that this project is a product of my own and not the one of someone else.
 */
using UnityEngine;

public class LoadScene : MonoBehaviour {

   
    public void Tuto()
    {
        GameManager.instance.TutoLevel();
    }
    public void Attack()
    {
        GameManager.instance.AttackLevel();
    }
    public void Wave()
    {
        GameManager.instance.WaveLevel();
    }
	public void Boss()
    {
        GameManager.instance.BossLevel();
    }
    public void resetting()
    {
        GameManager.instance.ResetHealth();
    }
}
