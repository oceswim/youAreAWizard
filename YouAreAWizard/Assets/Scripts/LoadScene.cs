using System.Collections;
using System.Collections.Generic;
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
