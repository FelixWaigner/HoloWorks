using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public GameObject myObject;
    public Material targetMaterial;
    public Material resetMaterial;

    public void SetMaterial()
    {
        GameObject mesh = myObject.transform.GetChild(0).gameObject;
        mesh.GetComponent<MeshRenderer>().material = targetMaterial;
    }

    public void ResetMaterial()
    {
        GameObject mesh = myObject.transform.GetChild(0).gameObject;
        mesh.GetComponent<MeshRenderer>().material = resetMaterial;
    }


}
