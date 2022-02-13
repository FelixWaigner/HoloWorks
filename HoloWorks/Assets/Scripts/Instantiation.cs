using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiation : MonoBehaviour
{
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
        MaterialObject.transform.position = spawnPos;
        //MaterialObject.transform.rotation = Quaternion.Euler(0, 0, playerRotation.z);
        GameObject ConfigObject = Instantiate(Resources.Load<GameObject>("Prefabs/ModelConfigPrefabs/BasicConfigs"), new Vector3(0, 0, 0), Quaternion.identity);


       

        //Set ConfigurationObject as parent
        MaterialObject.transform.SetParent(ConfigObject.transform);

        //Toggle Active state to apply changes
        ConfigObject.SetActive(false);
        ConfigObject.SetActive(true);
    }
}