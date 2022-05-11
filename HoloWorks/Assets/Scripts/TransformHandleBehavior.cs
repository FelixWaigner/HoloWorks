using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformHandleBehavior : MonoBehaviour
{
    public GameObject TransformHandle;
    public GameObject TransformTarget;
    private Vector3 InitialScale;

    private void Awake()
    {
        InitialScale = transform.localScale;
        UpdateTransform();
    }

    private void Update()
    {
        if(TransformHandle.transform.hasChanged)
        {
            UpdateTransform();
        }
    }

    void UpdateTransform()
    {
        float distance = Vector3.Distance(TransformHandle.transform.position, TransformTarget.transform.position);
        transform.localScale = new Vector3(InitialScale.x, distance / 2f, InitialScale.z);
        transform.localScale = new Vector3(InitialScale.y, distance / 2f, InitialScale.z);
        transform.localScale = new Vector3(InitialScale.z, distance / 2f, InitialScale.z);

    }
}
