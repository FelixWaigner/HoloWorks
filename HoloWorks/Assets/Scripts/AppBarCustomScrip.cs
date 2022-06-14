using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppBarCustomScrip : MonoBehaviour
{
    public GameObject BasicConfig;
    public GameObject TargetObject;

    //Dublicate the Object
    public void Dublicate()
    {
        var obj = Instantiate(BasicConfig, transform.position + (transform.forward * (1 / 2)), transform.rotation);

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
