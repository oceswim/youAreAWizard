using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeScene : MonoBehaviour
{
    private bool sceneload;
    // Start is called before the first frame update
    private void Start()
    {
        sceneload = false;
    }
    void Update()
    {
        if(sceneload)
        {
            sceneload = false;
            GameManager.instance.InitGame();
        }
    }
    public void AttackLevel()
    {
        
        UnityEngine.SceneManagement.SceneManager.LoadScene("AttackLevel");
        sceneload = true;

    }
    public void WaveLevel()
    {
        sceneload = true;
        UnityEngine.SceneManagement.SceneManager.LoadScene("WaveLevel");
    }
    public void BossLevel()
    {
        sceneload = true;
        UnityEngine.SceneManagement.SceneManager.LoadScene("BossLevel");

    }
    public void PlayGame()
    {
        //if never played
        //if (firstRun == 0)
        // {
        sceneload = true;
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        //}
       // else
       // {
            //load to latest save
      //  }
       

    }
    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        //if click on settings
        Application.Quit();
    }
    public void StartAgain()
    {
       
        //if dies can start at latest save
    }
}
