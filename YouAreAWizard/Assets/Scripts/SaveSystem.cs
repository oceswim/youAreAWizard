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
    public static int isSaving;
    public static void SavePlayer()
    {
        isSaving = 1;
        saved.Add(Game.current);
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.gd";
        FileStream file = File.Create(path);
        formatter.Serialize(file, saved);//converts player data to binary file
        file.Close();
    }
    public static void LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.gd";
        if (File.Exists(path))
        {

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            saved = (List<Game>)formatter.Deserialize(stream);
            stream.Close();

        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            
        }


    }
}
