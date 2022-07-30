using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class UIData : MonoBehaviour
{
    public string Title;
    public string Info;
    public string Security;
    public string Image;
    public string Video;

    public GameObject TitleObject;
    public GameObject InfoObject;
    public GameObject SecurityObject;
    public GameObject ImageObject;
    public GameObject VideoObject;

    private void Update()
    {
        if (TitleObject != null)
        {
            Title = TitleObject.GetComponent<Text>().text;
        }
        if (InfoObject != null)
        {
            Info = InfoObject.GetComponent<Text>().text;
        }
        if (SecurityObject != null)
        {
            Security = SecurityObject.GetComponent<Text>().text;
        }
        if (VideoObject != null)
        {
            Video = VideoObject.GetComponent<VideoPlayer>().url;
        }
    }
}