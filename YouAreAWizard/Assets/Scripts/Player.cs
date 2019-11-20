using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject savedMessage;
    private bool displaySave = false;
    private float timer = 2;
    public int playerHealth=10;
    private void Update()
    {
        if(displaySave)
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
        if (playerHealth < 1)
        {
            //stop game and ask if want to quit or go back to latest saved place;
        }     
        
    }
    public void SavePlayer()
    {

        SaveSystem.SavePlayer(this);
        displaySave = true;
        

        
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "checkPoint")
        {
            Debug.Log("ouch");
            Destroy(other.gameObject);
            SavePlayer();
        }
    }
    // Start is called before the first frame update

}
