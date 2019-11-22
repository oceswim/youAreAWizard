using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public Sprite[] lifeDisplay;
    public Image theImage;
    public static bool changeLife;

    void Update()
    {
        if (changeLife)
        {
            changeLife = false;
            UpdateLifeBar();
        }
        
    }
    private void UpdateLifeBar()
    {
        if (Game.current.thePlayer.health > 7)
        {
            theImage.sprite = lifeDisplay[0];
        }
        else if (Game.current.thePlayer.health == 7 || Game.current.thePlayer.health == 6)
        {
            theImage.sprite = lifeDisplay[1];
        }
        else if (Game.current.thePlayer.health == 5)
        {
            theImage.sprite = lifeDisplay[2];
        }
        else if (Game.current.thePlayer.health == 3 || Game.current.thePlayer.health == 2)
        {
            theImage.sprite = lifeDisplay[3];
        }
        else if (Game.current.thePlayer.health < 2)
        {
            theImage.sprite = lifeDisplay[4];
        }
    }
 
}
