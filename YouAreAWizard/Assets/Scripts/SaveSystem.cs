/*
 * Oceane Peretti - K1844498 - 3D Games programming Assignment 2
 * I confirm that this project is a product of my own and not the one of someone else.
 */
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public static class SaveSystem
{
    public static List<Game> saved = new List<Game>();
    public static int isSaving,level, health;
    public static void SavePlayer()
    {
        isSaving = 1;
        Game.current.thePlayer.health = GameManager.instance.playerHealth;
        Game.current.thePlayer.level = PlayerPrefs.GetInt("level");
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/playerInfo.gd";
        FileStream file = File.Create(path);
        PlayerData data = new PlayerData()
        {
            level = Game.current.thePlayer.level,
            health = Game.current.thePlayer.health
            
        };
        formatter.Serialize(file, data);//converts player data to binary file
        file.Close();
    }
    public static void LoadPlayer()
    {
        string path = Application.persistentDataPath + "/playerInfo.gd";
        if (File.Exists(path))
        {

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = (PlayerData)formatter.Deserialize(stream);
            stream.Close();
            
            level = data.level;
            health = data.health;
    
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            
        }


    }
}
