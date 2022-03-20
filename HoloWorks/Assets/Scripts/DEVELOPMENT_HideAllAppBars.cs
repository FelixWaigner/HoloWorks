using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEVELOPMENT_HideAllAppBars : MonoBehaviour
{

    public void HideAllAppBars()
    {
        foreach (GameObject AppBar in GameObject.FindGameObjectsWithTag("AppBar"))
        {
            GameObject AppBarFirstChild = AppBar.transform.GetChild(0).gameObject;
            //get current active sate of gameobject
            bool isActive = AppBarFirstChild.activeSelf;
            //set the different active state
            AppBarFirstChild.SetActive(!isActive);
        }
    }
}
