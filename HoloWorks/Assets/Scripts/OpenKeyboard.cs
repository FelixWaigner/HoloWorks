using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenKeyboard : MonoBehaviour
{
    public TouchScreenKeyboard keyboard;
    public Text TargetText;
    public string keyboardText;


    private void Update()
    {
        if (keyboard != null)
        {
            //keyboardText = keyboard.text;
            //Debug.Log(keyboardText);
            TargetText.text = keyboard.text;

        }
    }
    public void OpenSystemKeyboard()
    {
       keyboard = TouchScreenKeyboard.Open(TargetText.text, TouchScreenKeyboardType.Default, false, false, false, false);
    }
}
