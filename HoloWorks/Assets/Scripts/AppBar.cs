using Microsoft.MixedReality.Toolkit.UI.BoundsControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppBar : MonoBehaviour
{
    public GameObject BasicConfig;
    public GameObject RotatingObject;
    public Transform transformObject;
    public float offset;


    private void Update()
    {
        //Make AppBar sticky to the transformObject
        Vector3 pos = transformObject.position;
        pos.x += offset;
        transform.position = pos;

        //Rotate appbar to match parent
        var rotationVector = RotatingObject.transform.rotation.eulerAngles;
        BasicConfig.transform.rotation = Quaternion.Euler(rotationVector);
    }

    //Enable and disable the BoundsControl (Rotate and Scale)
    public void ToggleBoundsControl()
    {
        var script = RotatingObject.GetComponent<BoundsControl>();
        script.enabled = !script.enabled;
    }

    //Dublicate the Object
    public void Dublicate()
    {
        var obj = Instantiate(BasicConfig);

        //Delete The rigRoot in the Object GameObject (If not deleted the Object is not behaving as it should!)
        GameObject RigRoot = obj.transform.Find("Object").transform.Find("rigRoot").gameObject;
        Destroy(RigRoot);
    }

    //Delete the GameObject
    public void Delete()
    {
        Destroy(BasicConfig);
    }
}
