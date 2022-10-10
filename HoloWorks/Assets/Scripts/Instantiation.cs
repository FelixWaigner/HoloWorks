using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiation : MonoBehaviour
{
    public GameObject ParentAnchor;
    public GameObject MyObject;

    private GameObject _basicConfigs;

    public void Instantiate()
    {
        GameObject basicConfigsObject = Instantiate(Resources.Load<GameObject>("Prefabs/ModelConfigPrefabs/BasicConfigs"), ParentAnchor.transform);
        GameObject serializableObject = basicConfigsObject.transform.GetChild(0).gameObject;
        GameObject materialObject = Instantiate(MyObject, serializableObject.transform);

        //serializableObject.transform.localScale = materialObject.transform.localScale;
        serializableObject.transform.position = transform.position + transform.forward * (1 / 2);

       //Set ConfigurationObject name
        materialObject.name = MyObject.name;

        //Toggle Active state to apply changes
        basicConfigsObject.SetActive(false);
        basicConfigsObject.SetActive(true);

        _basicConfigs = basicConfigsObject;
    }

    public GameObject InstantiateSavedObject(GameObject markerModel)
    {
        MyObject = markerModel;

        Instantiate();
        //GameObject MaterialObject = Instantiate(markerModel);
        //MaterialObject.name = markerModel.name;
        //GameObject ConfigObject = Instantiate(Resources.Load<GameObject>("Prefabs/ModelConfigPrefabs/BasicConfigs"), ParentAnchor.transform);

        //MaterialObject.transform.SetParent(ConfigObject.transform.GetChild(0));
        //MaterialObject.transform.localScale = new Vector3(1, 1, 1);

        //ConfigObject.SetActive(false);
        //ConfigObject.SetActive(true);

        return _basicConfigs;
    }
}