using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        gameObject.transform.rotation = transform.rotation;

        GameObject instruction = Instantiate(Resources.Load<GameObject>("Prefabs/UI/UI"), gameObject.transform);
        instruction.name = "0";
    }
}
