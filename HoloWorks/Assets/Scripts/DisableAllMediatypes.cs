using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAllMediatypes : MonoBehaviour
{
    public GameObject SecurityButton;
    public GameObject DescriptionButton;
    public GameObject PictureButton;
    public GameObject VideoButton;
    public GameObject ArButton;

    public GameObject SecurityPannel;
    public GameObject DescriptionPannel;
    public GameObject PicturePannel;
    public GameObject VideoPannel;
    public GameObject ArPannel;
    public GameObject BigPicturePannel;
    public GameObject BigVideoPannel;

    // Start is called before the first frame update
    void Start()
    {
        DisableMediatypes();
    }


    void OnEnable()
    {
        DisableMediatypes();
    }

    void DisableMediatypes()
    {
        if (SecurityButton.GetComponent<Interactable>().CanSelect == true)
        {
            SecurityButton.GetComponent<Interactable>().IsToggled = false;
            SecurityPannel.SetActive(false);
        }

        if (DescriptionButton.GetComponent<Interactable>().CanSelect == true)
        {
            DescriptionButton.GetComponent<Interactable>().IsToggled = false;
            DescriptionPannel.SetActive(false);
        }

        if (PictureButton.GetComponent<Interactable>().CanSelect == true)
        {
            PictureButton.GetComponent<Interactable>().IsToggled = false;
            PicturePannel.SetActive(false);
        }

        if (VideoButton.GetComponent<Interactable>().CanSelect == true)
        {
            VideoButton.GetComponent<Interactable>().IsToggled = false;
            VideoPannel.SetActive(false);
        }

        if (ArButton.GetComponent<Interactable>().CanSelect == true)
        {
            Debug.Log("TEST");
            ArButton.GetComponent<Interactable>().IsToggled = false;
            ArPannel.SetActive(false);
        }

        if (BigPicturePannel.activeSelf == true)
        {
            BigPicturePannel.SetActive(false);
        }

        if (BigVideoPannel.activeSelf == true)
        {
            BigVideoPannel.SetActive(false);
        }
    }
}
