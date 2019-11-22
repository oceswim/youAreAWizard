using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public static Sprite[] lifeDisplay;
    public static Image theImage;
    public static bool changeLife;
    public static int health=0;

    
    public static void UpdateLifeBar(int damage)
    {   
        health -= damage;
        
        if (health > 7)
        {
            Game.current.thePlayer.health = health;
            theImage.sprite = lifeDisplay[0];
        }
        else if (health == 7 || health == 6)
        {
            Game.current.thePlayer.health = health;
            theImage.sprite = lifeDisplay[1];
        }
        else if (health == 5)
        {
            Game.current.thePlayer.health = health;
            theImage.sprite = lifeDisplay[2];
        }
        else if (health == 3 || health == 2)
        {
            Game.current.thePlayer.health = health;
            theImage.sprite = lifeDisplay[3];
        }
        else if (health < 2)
        {
            Game.current.thePlayer.health = health;
            theImage.sprite = lifeDisplay[4];
        }
  
       
    }
 
}
