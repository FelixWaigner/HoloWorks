using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using Microsoft.MixedReality.Toolkit.Utilities;

public class FilesInFolder : MonoBehaviour
{

    public GameObject ButtonCollectionContainer;

    void Start()
    {
    string path = Application.persistentDataPath + "/SaveData/";

         string [] files = System.IO.Directory.GetFiles(path);

        foreach (string file in files)
        {
            GameObject button =  Instantiate(Resources.Load<GameObject>("Prefabs/UI/ListButton"));
            button.GetComponent<ListButtonDataManager>().fileURL = file;
            button.transform.Find("IconAndText").Find("TextMeshPro").GetComponent<TextMeshPro>().text = Path.GetFileNameWithoutExtension(file);
            button.transform.SetParent(ButtonCollectionContainer.transform);
            ButtonCollectionContainer.GetComponent<GridObjectCollection>().UpdateCollection();
        }
    }
}
