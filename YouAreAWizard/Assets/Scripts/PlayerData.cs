using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData // here we store informations of our player
{
    public int level;
    public int health;
    public float[] position;//position coordinates

    public PlayerData(Player player)
    {
        level = PlayerPrefs.GetInt("CurrentLevel");
        health = player.playerHealth;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
