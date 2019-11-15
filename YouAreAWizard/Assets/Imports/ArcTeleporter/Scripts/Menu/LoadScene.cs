using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene : MonoBehaviour {
    UnityEngine.SceneManagement.Scene scene;

    void Start() {
        scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
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

}
