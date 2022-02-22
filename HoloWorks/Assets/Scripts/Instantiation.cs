using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiation : MonoBehaviour
{
    AppBar AppBar;

    public GameObject MyObject;

    public void Instantiate()
    {
        //Get Hololens position and rotation
        Vector3 playerPos = Camera.main.transform.position;
        Vector3 playerDirection = Camera.main.transform.forward;
        Quaternion playerRotation = Camera.main.transform.rotation;
        float spawnDistance = 1;

        Vector3 spawnPos = playerPos + playerDirection * spawnDistance;

        //Instantiate Objects in front of player
        GameObject MaterialObject = Instantiate(MyObject);
        //MaterialObject.transform.position = spawnPos;
//MaterialObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        GameObject ConfigObject = Instantiate(Resources.Load<GameObject>("Prefabs/ModelConfigPrefabs/BasicConfigs"));

        //Set ConfigurationObject as parent
        //MaterialObject.transform.SetParent(ConfigObject.transform);
        MaterialObject.transform.SetParent(ConfigObject.transform.GetChild(0));

        //Move the AppBar to the left border of the 3D Object
        GameObject AppBar = ConfigObject.transform.GetChild(1).gameObject;
        AppBar.transform.position = new Vector3(-MaterialObject.transform.localScale.x / 2 - 0.032f , 0, 0);

        //Toggle Active state to apply changes
        ConfigObject.SetActive(false);
        ConfigObject.SetActive(true);
            }
}