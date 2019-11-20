using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class SaveSystem
{

    public static void SavePlayer(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.saving";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);//takes player info to be saved

        formatter.Serialize(stream, data);//converts player data to binary file

        stream.Close();//
    }
    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.saving";
        if (File.Exists(path))
        {

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;

            stream.Close();
            return data;

        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }


    }
}
