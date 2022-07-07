using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class AuthorToggleActive : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Button;
    public GameObject AuthorContentButtons;
    public GameObject CompressedButtonVisuals;

    private TextMeshPro textMeshPro;
    private Color textOriginalColor;
    private Color iconOriginalColor;
    private Renderer iconRenderer;
    private bool isInitialized = false;

    private void Awake()
    {
        if (!isInitialized)
        {
            isInitialized = true;
            var iconParent = Button.transform.Find("IconAndText");
            textMeshPro = iconParent.GetComponentInChildren<TextMeshPro>();
            iconRenderer = iconParent.Find("UIButtonSquareIcon").gameObject.GetComponent<Renderer>();
            textOriginalColor = textMeshPro.color;
            iconOriginalColor = iconRenderer.material.color;

            setToggleDisabled();
        };

    }

    public void setToggleActive()
    {
        textMeshPro.color = textOriginalColor;
        iconRenderer.material.color = iconOriginalColor;
        Panel.SetActive(true);
        AuthorContentButtons.SetActive(true);
        Button.GetComponent<Interactable>().IsToggled = true;
        Button.GetComponent<Interactable>().CanSelect = true; 
        CompressedButtonVisuals.SetActive(true);

    }

    public void setToggleDisabled()
    {
        textMeshPro.color = Color.gray;
        iconRenderer.material.color = Color.gray;
        Panel.SetActive(false);
        AuthorContentButtons.SetActive(false);
        Button.GetComponent<Interactable>().IsToggled = false;
        Button.GetComponent<Interactable>().CanSelect = false;
        CompressedButtonVisuals.SetActive(false);
    }

}
