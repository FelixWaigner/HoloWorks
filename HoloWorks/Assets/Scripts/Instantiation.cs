using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiation : MonoBehaviour
{
    public GameObject ParentAnchor;
    public GameObject MyObject;

    public void Instantiate()
    {
        //Get Hololens position and rotation
        //Vector3 playerPos = Camera.main.transform.position;
        //Vector3 playerDirection = Camera.main.transform.forward;
        //Quaternion playerRotation = Camera.main.transform.rotation;
        //float spawnDistance = 1;

        //Vector3 spawnPos = playerPos + playerDirection * spawnDistance;

        //Instantiate Objects in front of player

        //GameObject MaterialObject = Instantiate(MyObject);
        GameObject MaterialObject = Instantiate(MyObject, new Vector3(0,0,0), Quaternion.identity);
        MaterialObject.name = MyObject.name;
        //MaterialObject.transform.position = spawnPos;
        //MaterialObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        //GameObject ConfigObject = Instantiate(Resources.Load<GameObject>("Prefabs/ModelConfigPrefabs/BasicConfigs"));
        GameObject ConfigObject = Instantiate(Resources.Load<GameObject>("Prefabs/ModelConfigPrefabs/BasicConfigs"), new Vector3(0,0,0), Quaternion.identity);
        //MaterialObject.transform.position = transform.position + transform.forward * (1 / 2);
        ConfigObject.transform.SetParent(ParentAnchor.transform);

        GameObject childObj = ConfigObject.transform.GetChild(0).gameObject;

        //Set ConfigurationObject as parent
        MaterialObject.transform.SetParent(childObj.transform);
        childObj.transform.position = transform.position + transform.forward * (1 / 2);

        //Move OffsetHelper to the left border of the 3D Object
        //GameObject ObjectPlaceholder = ConfigObject.transform.GetChild(0).gameObject;
        //GameObject OffsetHelper = ObjectPlaceholder.transform.GetChild(0).gameObject;
        //OffsetHelper.transform.position = new Vector3(-MaterialObject.transform.localScale.x / 2 , 0, 0);

        //Toggle Active state to apply changes
        ConfigObject.SetActive(false);
        ConfigObject.SetActive(true);
    }

    public GameObject InstantiateSavedObject(GameObject markerModel)
    {
        GameObject MaterialObject = Instantiate(markerModel);
        MaterialObject.name = markerModel.name;
        GameObject ConfigObject = Instantiate(Resources.Load<GameObject>("Prefabs/ModelConfigPrefabs/BasicConfigs"));
        ConfigObject.transform.SetParent(ParentAnchor.transform);

        MaterialObject.transform.SetParent(ConfigObject.transform.GetChild(0));

        ConfigObject.SetActive(false);
        ConfigObject.SetActive(true);

        return ConfigObject;
    }
}