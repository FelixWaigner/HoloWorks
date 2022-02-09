using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiation : MonoBehaviour
{
    public GameObject MyObject;

    public void Instantiate()
    {

        //Instantiate Objects
        GameObject MaterialObject = Instantiate((MyObject), new Vector3(0, 0, 0), Quaternion.identity);
        GameObject ConfigObject = Instantiate(Resources.Load<GameObject>("Prefabs/ModelConfigPrefabs/BasicConfigs"), new Vector3(0, 0, 0), Quaternion.identity);


       

        //Set ConfigurationObject as parent
        MaterialObject.transform.SetParent(ConfigObject.transform);

        //Toggle Active state to apply changes
        ConfigObject.SetActive(false);
        ConfigObject.SetActive(true);
    }
}