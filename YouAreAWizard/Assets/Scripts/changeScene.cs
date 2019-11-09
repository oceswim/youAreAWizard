using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeScene : MonoBehaviour
{
    private int firstRun = 0;
    // Start is called before the first frame update 
    public void AttackLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
    }
    public void WaveLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
    public void PlayGame()
    {
        //if never played
        //if (firstRun == 0)
       // {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        //}
       // else
       // {
            //load to latest save
      //  }
       

    }
    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        //if click on settings
        Application.Quit();
    }
    public void Switch()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 2)
        {
            WaveLevel();
        }
        else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 3)
        {
      
            AttackLevel();
        }
    }
    public void StartAgain()
    {
        //if dies can start at latest save
    }
}
