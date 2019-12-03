/*
 * Oceane Peretti - K1844498 - 3D Games programming Assignment 2
 * I confirm that this project is a product of my own and not the one of someone else.
 */
using UnityEngine;
using TMPro;
public class Player : MonoBehaviour
{

    public GameObject savedMessage;
    public static GameObject tryAgain;
    public static bool displaySave = false;
    private float timer = 2;
    private int single = 0;
    public int playerHealth;
    public static string theController;
    public static bool hurt,reset,regenerate;
    public GameObject lifeL,lifeR, healthIncreasedL, healthIncreasedR;
    private TMP_Text life;
    private GameObject healthIncrement;
    private bool found;
    private static AudioSource death;

    
    private void Start()
    {
   
        hurt =found=reset =regenerate=false;
        playerHealth = GameManager.instance.playerHealth;//takes health value from gamemanager
        tryAgain = GameObject.Find("Player/Canvas/Death");
        death = tryAgain.GetComponent<AudioSource>();
        Debug.Log(death.name);
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
                    healthIncrement = healthIncreasedL;
                    life = lifeL.GetComponentInChildren<TMP_Text>();
                    life.text = playerHealth.ToString();
                    break;
                case "lifeR":
                    lifeR.SetActive(true);
                    healthIncrement = healthIncreasedR;
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
            if(regenerate)
            {
                
                if (timer < .5f)
                {
                    healthIncrement.SetActive(false);
                    regenerate = false;
                    single = 0;
                    timer = 2;
                }
                else
                {
                    if(single==0)
                    {
                        single++;
                        increaseHealth();
                    }
                    timer -= Time.deltaTime;
                }
                
               
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
        Debug.Log(playerHealth + Game.current.thePlayer.health + GameManager.instance.playerHealth);
            UpdateLifeBar(playerHealth);
        
    }
    private void increaseHealth()
    {
        playerHealth += 1;
        healthIncrement.SetActive(true);
        Game.current.thePlayer.health = playerHealth;
        GameManager.instance.playerHealth = playerHealth;
        Debug.Log(playerHealth + Game.current.thePlayer.health + GameManager.instance.playerHealth);
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
    public static void DeathTheme()
    {
        death.Play();
    }
    public void StopTheme()
    {
        death.Stop();
    }



}
