using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AuthorDeleteText : MonoBehaviour
{
    public Text textContent;
    public GameObject KeyboardGo;

    public void DeleteText()
    {
        KeyboardGo.GetComponent<OpenKeyboard>().keyboardText = "";
        KeyboardGo.GetComponent<OpenKeyboard>().keyboardText = "";
        textContent.text = "";
    }
}
