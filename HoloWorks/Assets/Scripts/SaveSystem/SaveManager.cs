using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SaveManager 
{
    public static string directory = "/SaveData/";
    public static string fileName = "SaveFile.txt";


    public static void Save(SaveList<string> data)
    {
        string dir = Application.persistentDataPath + directory;

        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(dir + fileName, json);
    }

    public static SaveList<string> Load()
    {
        string fullPath = Application.persistentDataPath + directory + fileName;
        SaveList<string> data = new SaveList<string>();

        if(File.Exists(fullPath))
        {
            Debug.Log(fullPath);
            string json = File.ReadAllText(fullPath);
            Debug.Log(json);
            data = JsonUtility.FromJson<SaveList<string>>(json);
        }
        else
        {
            Debug.Log("Save file does not exist");
        }

        return data;
    }
}
