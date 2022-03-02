using Microsoft.MixedReality.Toolkit.UI.BoundsControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppBar : MonoBehaviour
{
    public GameObject BasicConfig;
    public GameObject RotatingObject;
    public Transform TransformObject;
    public float Offset;
    private bool rotating = false;

    private void Update()
    {
        //Make AppBar sticky to the transformObject
        //if (rotating == false)
        //{
            Vector3 pos = TransformObject.position;
            pos.x += Offset;
            transform.position = pos;
        //}

        //Rotate Appbar to match parent
        //var rotationVector = RotatingObject.transform.rotation.eulerAngles;
        //BasicConfig.transform.rotation = Quaternion.Euler(rotationVector);

    }

    public void RotationStart()
    {
        rotating = true;
    }

    public void RotationEnd()
    {
        rotating = false;
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

    //Lock GameObject in place
    public void Lock()
    {
        var script = BasicConfig.GetComponent<Microsoft.MixedReality.Toolkit.UI.ManipulationHandler>();
        script.enabled = !script.enabled;
    }
}
