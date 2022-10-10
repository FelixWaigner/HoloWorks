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
        gameObject.transform.position = transform.position;
        gameObject.transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y - Mathf.Sin(2 * Mathf.PI * transform.rotation.eulerAngles.x / 360f) * transform.rotation.eulerAngles.z, 0);

        if (gameObject.transform.childCount > 0) return;

        GameObject instruction = Instantiate(Resources.Load<GameObject>("Prefabs/UI/UI"), gameObject.transform);
        instruction.name = "0";
    }
}
