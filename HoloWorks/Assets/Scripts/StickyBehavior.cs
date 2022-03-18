using Microsoft.MixedReality.Toolkit.UI.BoundsControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyBehavior : MonoBehaviour
{
    public GameObject BasicConfig;
    public GameObject RotatingObject;
    public Transform TransformObject;
    public float Offset;

    private void Update()
    {
        var rotationVector = RotatingObject.transform.rotation.eulerAngles;
        BasicConfig.transform.rotation = Quaternion.Euler(rotationVector);
        //Make AppBar sticky to the transformObject
        /*
            Vector3 pos = TransformObject.position;
            pos.x += Offset;
            transform.position = pos;
        */
    }
}
