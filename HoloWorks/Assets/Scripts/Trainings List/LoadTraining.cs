using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTraining : MonoBehaviour
{

    public void loadTraining()
    {
        GameObject.Find("TraineeTrainerManager").GetComponent<TraineeTrainerManager>().filePath = this.gameObject.GetComponent<ListButtonDataManager>().fileURL;
        GameObject.Find("TraineeTrainerManager").GetComponent<TraineeTrainerManager>().user = "Trainee";
       SceneManager.LoadScene("Main");
    }
}
