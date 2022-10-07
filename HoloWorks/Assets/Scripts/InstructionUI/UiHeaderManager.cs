using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiHeaderManager : MonoBehaviour
{
    public TextMeshPro StepCountTextObject;
    public TextMeshPro TrainingNameTextObject;
    private GameObject anchor;
    // Start is called before the first frame update
    void Awake()
    {
        anchor = GameObject.FindGameObjectWithTag("Anchor");
        TrainingNameTextObject.text = GameObject.Find("TraineeTrainerManager").GetComponent<TraineeTrainerManager>().fileName;

    }

    // Update is called once per frame
    void Update()
    {
        int allSteps = anchor.transform.childCount;
        int currentStep = int.Parse(gameObject.transform.parent.transform.parent.name) + 1;

        string text = "Schritt " + currentStep + "/" + allSteps;

        StepCountTextObject.text = text;
    }
}
