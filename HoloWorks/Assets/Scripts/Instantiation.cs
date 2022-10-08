using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiation : MonoBehaviour
{
    public GameObject ParentAnchor;
    public GameObject MyObject;

    public void Instantiate()
    {

        GameObject MaterialObject = Instantiate(MyObject, new Vector3(0,0,0), Quaternion.identity);
        MaterialObject.name = MyObject.name;
        GameObject ConfigObject = Instantiate(Resources.Load<GameObject>("Prefabs/ModelConfigPrefabs/BasicConfigs"), ParentAnchor.transform);
        ConfigObject.transform.SetParent(ParentAnchor.transform);

        GameObject childObj = ConfigObject.transform.GetChild(0).gameObject;

        childObj.transform.localScale = MaterialObject.transform.localScale;

       //Set ConfigurationObject as parent
        MaterialObject.transform.SetParent(childObj.transform);

        childObj.transform.position = transform.position + transform.forward * (1 / 2);


        //Toggle Active state to apply changes
        ConfigObject.SetActive(false);
        ConfigObject.SetActive(true);
    }

    public GameObject InstantiateSavedObject(GameObject markerModel)
    {
        GameObject MaterialObject = Instantiate(markerModel);
        MaterialObject.name = markerModel.name;
        GameObject ConfigObject = Instantiate(Resources.Load<GameObject>("Prefabs/ModelConfigPrefabs/BasicConfigs"), ParentAnchor.transform);
        ConfigObject.transform.SetParent(ParentAnchor.transform);

        MaterialObject.transform.SetParent(ConfigObject.transform.GetChild(0));
        MaterialObject.transform.localScale = new Vector3(1, 1, 1);

        ConfigObject.SetActive(false);
        ConfigObject.SetActive(true);




        return ConfigObject;
    }
}