using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class UIData : MonoBehaviour
{
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
    public GameObject AR;
    public List<ArElement> arElements;
    

     

    public void WriteUiData()
    {

        Title = TitleObject.GetComponent<Text>().text;
        Info = InfoObject.GetComponent<Text>().text;          
        Security = SecurityObject.GetComponent<Text>().text;     
        Video = VideoObject.GetComponent<VideoPlayer>().url;
        Image = ImageObject.GetComponent<PhotoCaptureExample>().filePath;


        arElements.Clear();
        foreach(Transform element in AR.transform)
        {
            ArElement data = new ArElement();
            GameObject arObj = element.transform.Find("Object").gameObject;
            data.name = arObj.transform.GetChild(0).name;

            Debug.Log(element.name);
            data.position = new float[3];
            data.position[0] = arObj.transform.position.x;
            data.position[1] = arObj.transform.position.y;
            data.position[2] = arObj.transform.position.z;
            arElements.Add(data);
        }
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