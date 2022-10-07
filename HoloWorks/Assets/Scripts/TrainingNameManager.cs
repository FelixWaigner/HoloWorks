using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TrainingNameManager : MonoBehaviour
{
    public Text Text;
    string managerText;

    // Update is called once per frame
    void Update()
    {
        managerText  = GameObject.Find("TraineeTrainerManager").GetComponent<TraineeTrainerManager>().fileName = Text.text;
    }

    public void NextScene()
    {
        if (managerText != "")
        {
            SceneManager.LoadScene("Main");
        }
    }
}
