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

    public void CopyTransformValues(Transform transform)
    {
        gameObject.transform.position = transform.position;
        gameObject.transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y - Mathf.Sin(2 * Mathf.PI * transform.rotation.eulerAngles.x / 360f) * transform.rotation.eulerAngles.z, 0);

        if (gameObject.transform.childCount > 0) return;

        GameObject instruction = Instantiate(Resources.Load<GameObject>("Prefabs/UI/UI"), gameObject.transform);
        instruction.name = "0";
    }
}
