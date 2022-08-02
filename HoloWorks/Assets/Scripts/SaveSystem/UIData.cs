using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class UIData : MonoBehaviour
{
    public GameObject TitleButton;
    public GameObject InfoButton;
    public GameObject SecurityButton;
    public GameObject ImageButton;
    public GameObject VideoButton;

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

     

    public void WriteUiData()
    {

            Title = TitleObject.GetComponent<Text>().text;
            Info = InfoObject.GetComponent<Text>().text;          
            Security = SecurityObject.GetComponent<Text>().text;     
            Video = VideoObject.GetComponent<VideoPlayer>().url;
            Image = ImageObject.GetComponent<PhotoCaptureExample>().filePath;
        
    }

    public void saveDataButtonHelper()
    {
        var saveManagerObject = GameObject.Find("SaveManager").GetComponent<SceneDataObject>();
        saveManagerObject.saveData();
    }

    public void loadDataButtonHelper()
    {
        var saveManagerObject = GameObject.Find("SaveManager").GetComponent<SceneDataObject>();
        saveManagerObject.loadData();
    }
}