using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneDataObject : MonoBehaviour
{
    public GameObject anchor;
    public string outputString;
    [SerializeField] private SaveList<string> saveObjects;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            saveData();
            SaveManager.Save(saveObjects);
            Debug.Log("...SAVE...");
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            saveObjects = SaveManager.Load();
            loadData();
            Debug.Log("...LOAD...");
        }
    }

    public void saveData()
    {
        
        saveObjects.data.Clear();

        foreach (Transform child in anchor.transform)
        {
            SaveObject data = new SaveObject();
           
            var dataClass = child.Find("InstructionUI").Find("DataManager").GetComponent<UIData>();
            data.id = child.name;
            data.Title = dataClass.Title;
            data.Info = dataClass.Info;
            string json = JsonUtility.ToJson(data);

            saveObjects.data.Add(json);
        }

        string outputString = JsonUtility.ToJson(saveObjects);

        Debug.Log(outputString);
    }

    public void loadData()
    {
        foreach (Transform child in anchor.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        foreach (object obj in saveObjects.data)
        {
            GameObject UiObject = Instantiate(Resources.Load<GameObject>("Prefabs/UI/UI"));
            UiObject.transform.SetParent(anchor.transform);
            Debug.Log(obj.ToString());
            
        }
    }
}

public class SaveObject
{
    public string id;
    public string Title;
    public string Info;
    public string Security;
    public string Image;
    public string Video;
}

[System.Serializable]
public class SaveList<T>
{
    public List<T> data;
}

