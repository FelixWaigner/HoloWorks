using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleActive : MonoBehaviour
{
    public void ToggleObjectActive()
    {

        bool isActive = gameObject.activeSelf;

        gameObject.SetActive(!isActive);
    }
}
