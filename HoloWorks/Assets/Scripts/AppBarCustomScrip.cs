using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppBarCustomScrip : MonoBehaviour
{
    public GameObject BasicConfig;
    public GameObject TargetObject;

    //Dublicate the Object
    public void Duplicate()
    {
        var obj = Instantiate(BasicConfig, transform.parent.parent);
        obj.name = "BasicConfigs(Clone)";

        obj.transform.localPosition = Vector3.zero;
        obj.transform.localRotation = Quaternion.identity;
        obj.transform.localScale = Vector3.one;

        var child = obj.transform.GetChild(0);
        child.transform.localPosition += new Vector3(-0.2f, 0, 0);

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
        var script = TargetObject.GetComponent<Microsoft.MixedReality.Toolkit.UI.ManipulationHandler>();
        script.enabled = !script.enabled;
    }
}
