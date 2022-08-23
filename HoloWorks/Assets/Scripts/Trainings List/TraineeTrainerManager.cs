using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraineeTrainerManager : MonoBehaviour
{
    private static GameObject instance;
    public string user;
    public string filePath;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if(instance == null)
        {
            instance = this.gameObject;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
