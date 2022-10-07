using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTraining : MonoBehaviour
{
    public TextMeshPro buttonText;

    public void loadTraining()
    {
        GameObject.Find("TraineeTrainerManager").GetComponent<TraineeTrainerManager>().filePath = this.gameObject.GetComponent<ListButtonDataManager>().fileURL;
        GameObject.Find("TraineeTrainerManager").GetComponent<TraineeTrainerManager>().user = "Trainee";
        GameObject.Find("TraineeTrainerManager").GetComponent<TraineeTrainerManager>().fileName = buttonText.text;
        SceneManager.LoadScene("Main");
    }
}
