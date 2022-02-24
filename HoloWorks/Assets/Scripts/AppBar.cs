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
}
