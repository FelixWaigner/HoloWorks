using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string nextScene;

    public void SceneChanger()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void setTrainerTrainee(string person)
    {
        GameObject.Find("TraineeTrainerManager").GetComponent<TraineeTrainerManager>().user = person;
    }

    public void TariningListMenu()
    {
        var user = GameObject.Find("TraineeTrainerManager").GetComponent<TraineeTrainerManager>().user;

        if(user == "Trainee")
        {
            SceneManager.LoadScene("List");
        }
        else if(user == "Trainer")
        {
            SceneManager.LoadScene("AuthorList");
        }
    }
}
