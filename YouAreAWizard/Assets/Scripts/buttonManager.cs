using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class buttonManager : MonoBehaviour
{
    public Button menuButton;
    public Button continueButton;
    public Button startOver;
    public GameObject firstLoadPanel; 
    public GameObject panelNormal;
    private int choice;
    void Start()
    {
        menuButton.onClick.AddListener(TaskOnClick);
        continueButton.onClick.AddListener(KeepPlaying);
        startOver.onClick.AddListener(RestartGame);
    }
 
    void TaskOnClick()
    {
        choice =GameManager.theMenu;
        Debug.Log("CHOICE " + choice);
      
            switch(choice)
            {
                case 0:
                    firstLoadPanel.SetActive(true);
                    break;
                case 1:
                    panelNormal.SetActive(true);
                    break;

            }
        
    }

    void KeepPlaying()
    {
        GameManager.instance.Continue();

    }

    void RestartGame()
    {
        GameManager.instance.NewGame();
        GameManager.instance.WaveLevel();
    }
}
