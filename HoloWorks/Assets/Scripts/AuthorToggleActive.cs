using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuthorToggleActive : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Button;
    public GameObject AuthorContentButtons;



    public void setToggleActive()
    {
        Panel.SetActive(true);
        AuthorContentButtons.SetActive(true);
        Button.GetComponent<Interactable>().IsToggled = true;
        Button.GetComponent<Interactable>().CanSelect = true;
    }

    public void setToggleDisabled()
    {
        Panel.SetActive(false);
        AuthorContentButtons.SetActive(false);
        Button.GetComponent<Interactable>().IsToggled = false;
        Button.GetComponent<Interactable>().CanSelect = false;
    }
}
