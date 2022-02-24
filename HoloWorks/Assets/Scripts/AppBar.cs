using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppBar : MonoBehaviour
{
    public Transform transformObject;
    public float offset;
    private void Update()
    {
        Vector3 pos = transformObject.position;
        pos.x += offset;
        transform.position = pos;
    }
}
