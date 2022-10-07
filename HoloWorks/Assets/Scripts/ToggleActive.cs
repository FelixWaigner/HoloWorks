using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleActive : MonoBehaviour
{
    public void ToggleObjectActive()
    {

        //get current active sate of gameobject
        bool isActive = gameObject.activeSelf;

        //set the different active state
        gameObject.SetActive(!isActive);
    }

    public void DestoryObject()
    {
        Destroy(gameObject);
    }
}


