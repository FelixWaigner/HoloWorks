using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Author3DLibrary : MonoBehaviour
{
    public GameObject MarkerMenu;
    public float distance;

    public void openMarkerMenu ()
    {

        //get current active sate of gameobject
        bool isActive = MarkerMenu.activeSelf;

        if (isActive)
        {
            //MarkerMenu.transform.position = Camera.main.transform.position + Camera.main.transform.forward * distance;
            MarkerMenu.transform.position = Camera.main.transform.position + (Camera.main.transform.forward * distance);
        }
        else
        {
            MarkerMenu.SetActive(true);
            //MarkerMenu.transform.position = Camera.main.transform.position + Camera.main.transform.forward * distance;
            MarkerMenu.transform.position = Camera.main.transform.position + (Camera.main.transform.forward * distance);
        }
    }
}
