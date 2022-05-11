using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonIcon : MonoBehaviour
{
    public GameObject ObjectIcon;

    private void Start()
    {
        GameObject visuals = Instantiate(ObjectIcon);
    }
}
