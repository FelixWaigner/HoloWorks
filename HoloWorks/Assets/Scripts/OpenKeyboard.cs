using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenKeyboard : MonoBehaviour
{
    public readonly Dictionary<Text, TouchScreenKeyboard> keyboardDictionary = new Dictionary<Text, TouchScreenKeyboard>();
    public Text TargetText;
    public string keyboardText;


    private void Update()
    {
        if (keyboardDictionary != null &&keyboardDictionary.TryGetValue(TargetText, out var keyboard))
        {
            //keyboardText = keyboard.text;
            //Debug.Log(keyboardText);
            TargetText.text = keyboard.text;

        }
    }
    public void OpenSystemKeyboard()
    {
        keyboardDictionary[TargetText] = TouchScreenKeyboard.Open(TargetText.text, TouchScreenKeyboardType.Default, false, false, false, false);
    }
}
