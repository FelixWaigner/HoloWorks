using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SaveManager 
{
    public static string directory = "/SaveData/";


    public static void Save(SaveList data)
    {
        string dir = Application.persistentDataPath + directory;

        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);

        string json = JsonUtility.ToJson(data);

        string fileName = GameObject.Find("TraineeTrainerManager").GetComponent<TraineeTrainerManager>().fileName;
        File.WriteAllText(dir + fileName, json);
        Debug.Log(dir + fileName);
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