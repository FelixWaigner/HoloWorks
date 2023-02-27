using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.UI;

public class FilesInFolder : MonoBehaviour
{

    public GameObject ButtonCollectionContainer;
    public GameObject ScrollingList;

    void Start()
    {
        createList();
    }

    public void createList()
    {
        if (GameObject.FindGameObjectWithTag("TrainingNameManager").GetComponent<TraineeTrainerManager>().user == "Trainee")
        {

            ScrollingList.GetComponent<ScrollingObjectCollection>().enabled = true;
            string path = Application.persistentDataPath + "/SaveData/";

            string[] files = System.IO.Directory.GetFiles(path);

            foreach (string file in files)
            {
                GameObject button = Instantiate(Resources.Load<GameObject>("Prefabs/UI/ListButton"));
                button.GetComponent<ListButtonDataManager>().fileURL = file;
                button.transform.Find("IconAndText").Find("TextMeshPro").GetComponent<TextMeshPro>().text = Path.GetFileNameWithoutExtension(file);
                button.transform.SetParent(ButtonCollectionContainer.transform);
                ButtonCollectionContainer.GetComponent<GridObjectCollection>().UpdateCollection();
            }

            ScrollingList.GetComponent<ScrollingObjectCollection>().enabled = true;
        }
        else if (GameObject.FindGameObjectWithTag("TrainingNameManager").GetComponent<TraineeTrainerManager>().user == "Trainer")
        {

            ScrollingList.GetComponent<ScrollingObjectCollection>().enabled = true;
            string path = Application.persistentDataPath + "/SaveData/";

            string[] files = System.IO.Directory.GetFiles(path);

            foreach (string file in files)
            {
                GameObject button = Instantiate(Resources.Load<GameObject>("Prefabs/UI/ListButtonDelete"));
                GameObject listButton = button.transform.Find("ListButton").gameObject;

                listButton.GetComponent<ListButtonDataManager>().fileURL = file;
                listButton.transform.Find("IconAndText").Find("TextMeshPro").GetComponent<TextMeshPro>().text = Path.GetFileNameWithoutExtension(file);
                button.transform.SetParent(ButtonCollectionContainer.transform);
                ButtonCollectionContainer.GetComponent<GridObjectCollection>().UpdateCollection();
            }

            ScrollingList.GetComponent<ScrollingObjectCollection>().enabled = true;
        }
    }
}
