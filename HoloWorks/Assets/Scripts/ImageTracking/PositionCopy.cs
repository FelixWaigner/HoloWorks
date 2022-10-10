using Microsoft.MixedReality.Toolkit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.XR.ARSubsystems.XRCpuImage;

public class PositionCopy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetRotation(GameObject mesh)
    {
        foreach (var normal in mesh.GetComponent<MeshFilter>().mesh.normals) Debug.Log(gameObject.transform.TransformPoint(normal));

        var a = gameObject.transform.GetChild(0).TransformPoint(mesh.GetComponent<MeshFilter>().mesh.vertices[0]);
        var b = gameObject.transform.GetChild(0).TransformPoint(mesh.GetComponent<MeshFilter>().mesh.vertices[1]);
        var c = gameObject.transform.GetChild(0).TransformPoint(mesh.GetComponent<MeshFilter>().mesh.vertices[2]);
        var d = gameObject.transform.GetChild(0).TransformPoint(mesh.GetComponent<MeshFilter>().mesh.vertices[3]);

        Debug.Log(gameObject.transform.TransformPoint(a));
        Debug.Log(gameObject.transform.TransformPoint(b));
        Debug.Log(gameObject.transform.TransformPoint(c));
        Debug.Log(gameObject.transform.TransformPoint(d));
    }

    public void CopyTransformValues(Transform transform)
    {
        var angles = transform.rotation.eulerAngles;

        //var y = angles.y switch
        //{
        //    _ when angles.x > 180 => angles.y + angles.z
        //    _ when angles.x < 180 => angles.y + angles.z - 180
        //    _ => 0,
        //};

        Debug.Log(angles);
        gameObject.transform.position = transform.position;
        //gameObject.transform.rotation *= new Quaternion(0, Mathf.Sin(y), 0, Mathf.Cos(y));

        GameObject instruction = Instantiate(Resources.Load<GameObject>("Prefabs/UI/UI"), gameObject.transform);
        instruction.name = "0";
    }
}
