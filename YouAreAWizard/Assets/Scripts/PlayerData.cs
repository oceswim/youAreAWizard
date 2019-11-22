using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData // here we store informations of our player
{
    public int level;
    public int health;
    
    public PlayerData()
    {
        level = 2;
        health = 10;
    }
}
