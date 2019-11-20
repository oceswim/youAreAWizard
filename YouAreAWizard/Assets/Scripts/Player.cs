using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public int playerHealth=10;
    private void Update()
    {
        if (playerHealth < 1)
        {
            //stop game and ask if want to quit or go back to latest saved place;
        }
        if(PlayerPrefs.HasKey("sceneLoaded"))
        {
            if(PlayerPrefs.GetInt("sceneLoaded")==1)
            {
                PlayerPrefs.SetInt("sceneLoaded", 1);
                SavePlayer();
            }
        }

    }
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        playerHealth = data.health;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;

        GameManager.instance.LoadScene(data.level);
    }
    public void UpdateHealth(int health)
    {
        playerHealth -= health;
    }
    public void ResetHealth()
    {
    
        playerHealth = 10;
    }
    // Start is called before the first frame update
   
}
