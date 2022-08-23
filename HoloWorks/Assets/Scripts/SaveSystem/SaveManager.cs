using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SaveManager 
{
    public static string directory = "/SaveData/";
    public static string fileName = "SaveFile.txt";


    public static void Save(SaveList data)
    {
        string dir = Application.persistentDataPath + directory;

        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(dir + fileName, json);
    }

    public static SaveList Load(string filePath)
    {
        //string fullPath = Application.persistentDataPath + directory + fileName;
        SaveList data = new SaveList();

        if(File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            data = JsonUtility.FromJson<SaveList>(json);
        }
        else
        {
            Debug.Log("Save file does not exist");
        }

        return data;
    }
}
