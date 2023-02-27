using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Utilities;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTraining : MonoBehaviour
{
    public TextMeshPro buttonText;

    public void loadTraining()
    {
        GameObject.Find("TraineeTrainerManager").GetComponent<TraineeTrainerManager>().filePath = this.gameObject.GetComponent<ListButtonDataManager>().fileURL;
        GameObject.Find("TraineeTrainerManager").GetComponent<TraineeTrainerManager>().fileName = buttonText.text;
        SceneManager.LoadScene("Main");
    }

    public void DeleteTraining(GameObject listButton)
    {
        GameObject list = GameObject.Find("GridObjectCollection");
        File.Delete(listButton.GetComponent<ListButtonDataManager>().fileURL);
        Destroy(gameObject);
        SceneManager.LoadScene("AuthorList");
    }
}
