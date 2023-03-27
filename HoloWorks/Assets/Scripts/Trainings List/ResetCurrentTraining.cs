using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCurrentTraining : MonoBehaviour
{
    public void ResetTrainingData()
    {
        var TTManager = GameObject.Find("TraineeTrainerManager").GetComponent<TraineeTrainerManager>();

        TTManager.fileName = "";
        TTManager.filePath = "";
    }
}

