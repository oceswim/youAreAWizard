using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Player : MonoBehaviour
{
    public GameObject savedMessage;
    public static GameObject tryAgain;
    public static bool displaySave = false;
    private float timer = 2;
    public int playerHealth;
    //public Sprite[] lifeDisplay;
    public static string theController;
    public static bool hurt,reset;
    public GameObject lifeL,lifeR;
    private TMP_Text life;
    private bool found;
    //private GameObject theCanvas;
    //private Image theImage;
    
    private void Start()
    {
        
        hurt =found=reset =false;
        playerHealth = GameManager.instance.playerHealth;//takes health value from gamemanager
        tryAgain = GameObject.Find("Player/Canvas/Death");
        Debug.Log(playerHealth);
    }
    private void Update()
    {
        if (!found)
        {
            switch (theController)
            {
                case "lifeL":
                    lifeL.SetActive(true);
                    life = lifeL.GetComponentInChildren<TMP_Text>();
                    life.text = playerHealth.ToString();
                    break;
                case "lifeR":
                    lifeR.SetActive(true);
                    life = lifeR.GetComponentInChildren<TMP_Text>();
                    life.text = playerHealth.ToString();
                    break;
            }
            found |= (theController.Equals("lifeL") || theController.Equals("lifeR"));
        }
        else
        {
            if (displaySave)
            {
                savedMessage.SetActive(true);
                if (timer < .5f)
                {
                    savedMessage.SetActive(false);
                    displaySave = false;
                    timer = 2;
                }
                else
                {
                    timer -= Time.deltaTime;
                }

            }
            if (PlayerPrefs.HasKey("checkpoint"))
            {
                //saves player infos
                SaveSystem.SavePlayer();
                PlayerPrefs.DeleteKey("checkpoint");

            }
            if (hurt)
            {

                decreaseHealth();
                hurt = false;
            }
        }
        
    }
    public void saveHealth()
    {
        GameManager.instance.playerHealth = playerHealth;
        Game.current.thePlayer.health = playerHealth;
        SaveSystem.SavePlayer();
    }


    private void decreaseHealth()
    {
        
            playerHealth -= 1;
            Game.current.thePlayer.health = playerHealth;
            GameManager.instance.playerHealth = playerHealth;
            UpdateLifeBar(playerHealth);
        
    }
    public void UpdateLifeBar(int health)
    {
       
        if (health > 0)
        {
            life.text = health.ToString();
        }
        else
        {
            life.text = "";
        }
    }



}
