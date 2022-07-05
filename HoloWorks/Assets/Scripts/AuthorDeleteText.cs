using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AuthorDeleteText : MonoBehaviour
{
    public Text textContent;

    public void DeleteText()
    {
        textContent.text = "test";
    }
}
