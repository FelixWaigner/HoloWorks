using Microsoft.MixedReality.Toolkit.Examples.Demos;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class SceneDataObject : MonoBehaviour
{
    public GameObject anchor;
    public SaveList saveObjects = new SaveList();
    //public GameObject[] dataManagers;

    public void saveData()
    {
        saveObjects.saveData.Clear();

        foreach (Transform child in anchor.transform)
        {
            child.gameObject.SetActive(true);
        }

        foreach (Transform child in anchor.transform)
        {
            SaveObject data = new SaveObject();
           
            var dataClass = child.Find("InstructionUI").Find("DataManager").GetComponent<UIData>();
            dataClass.WriteUiData();
            data.id = child.name;
            data.Title = "asdf1qwer";
            data.Info = dataClass.Info;
            data.Security = dataClass.Security;
            data.Image = dataClass.Image;
            data.Video = dataClass.Video;
            data.Elements = dataClass.arElements;

            saveObjects.saveData.Add(data);
        }

        SaveManager.Save(saveObjects);
        Debug.Log("...SAVE...");

        foreach (Transform child in anchor.transform)
        {
            if (child.name != "0")
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    public void loadData()
    {
        saveObjects = SaveManager.Load();

        foreach (Transform child in anchor.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (SaveObject obj in saveObjects.saveData)
        {
            GameObject UiObject = Instantiate(Resources.Load<GameObject>("Prefabs/UI/UI"));
            UiObject.transform.SetParent(anchor.transform);
            UiObject.transform.position = new Vector3(0, 0, 0);
            UiObject.name = obj.id;
            

            GameObject textfield = UiObject.transform.Find("OptionsHandMenu").Find("MenuContent").Find("Tabs").Find("Title").gameObject;
            var updateText = textfield.GetComponent<SystemKeyboardExample>();
            updateText.debugMessage.text = "asdasdasdasd";

            UiObject.transform.Find("InstructionUI").Find("UITextSelawikSemibold").Find("InstructionText").GetComponent<Text>().text = "hallo";


            //Add Video
            if (obj.Video != "")
            {
                UiObject.transform.Find("OptionsHandMenu").Find("MenuContent").Find("Tabs").Find("Video").gameObject.SetActive(true);
                UiObject.transform.Find("OptionsHandMenu").Find("MenuContent").Find("Tabs").Find("Video").GetComponent<AuthorToggleActive>().setToggleActive();
                UiObject.transform.Find("OptionsHandMenu").Find("MenuContent").Find("Tabs").Find("Video").gameObject.SetActive(false);

                var updateVideo = UiObject.transform.Find("InstructionUI").Find("Mediatypes").Find("Video").Find("VideoContainer").Find("Video Player").GetComponent<VideoPlayer>();
                updateVideo.url = obj.Video;
            }

            

            //Add Picture
            if(obj.Image != "")
            {
                UiObject.transform.Find("OptionsHandMenu").Find("MenuContent").Find("Tabs").Find("Picture").gameObject.SetActive(true);
                UiObject.transform.Find("OptionsHandMenu").Find("MenuContent").Find("Tabs").Find("Picture").GetComponent<AuthorToggleActive>().setToggleActive();
                UiObject.transform.Find("OptionsHandMenu").Find("MenuContent").Find("Tabs").Find("Picture").gameObject.SetActive(false);

                var updatePicture = UiObject.transform.Find("OptionsHandMenu").Find("PhotoManager").GetComponent<PhotoCaptureExample>();
                updatePicture.filePath = obj.Image;
                updatePicture.LoadImage(obj.Image);
            }

            if (obj.Elements.Count > 0 )
            {

                UiObject.transform.Find("OptionsHandMenu").Find("MenuContent").Find("Tabs").Find("AR").gameObject.SetActive(true);
                UiObject.transform.Find("OptionsHandMenu").Find("MenuContent").Find("Tabs").Find("AR").GetComponent<AuthorToggleActive>().setToggleActive();
                UiObject.transform.Find("OptionsHandMenu").Find("MenuContent").Find("Tabs").Find("AR").gameObject.SetActive(false);

                foreach (ArElement element in obj.Elements)
                {
                   
                    GameObject newArObj = UiObject.transform.Find("3D Elements").GetComponent<Instantiation>().InstantiateSavedObject(Resources.Load<GameObject>("3D Objects/" + element.name));
                    Vector3 pos;
                    pos.x = element.position[0];
                    pos.y = element.position[1];
                    pos.z = element.position[2];
                    newArObj.transform.GetChild(0).localPosition = pos;

                    Vector3 rot;
                    rot.x = element.rotation[0];
                    rot.y = element.rotation[1];
                    rot.z = element.rotation[2];
                    newArObj.transform.GetChild(0).rotation = Quaternion.Euler(rot);

                    Vector3 scale;
                    scale.x = element.scale[0];
                    scale.y = element.scale[1];
                    scale.z = element.scale[2];
                    newArObj.transform.GetChild(0).localScale = scale;
                }
            }

            if (UiObject.name != "0")
            {
                UiObject.gameObject.SetActive(false);
            }

            var UiDataManager = UiObject.transform.Find("InstructionUI").Find("DataManager").gameObject.GetComponent<UIData>();
            UiDataManager.Title = obj.Title;
            UiDataManager.Info = obj.Info;
            UiDataManager.Security = obj.Security;
            UiDataManager.Image = obj.Image;
            UiDataManager.Video = obj.Video;
        }


        Debug.Log("...LOAD...");
    }
}

[System.Serializable]
public class SaveObject
{
    public string id;
    public string Title;
    public string Info;
    public string Security;
    public string Image;
    public string Video;
    public List<ArElement> Elements;
}


[System.Serializable]
public class ArElement
{
    public string name;
    public float[] position;
    public float[] rotation;
    public float[] scale;
}

[System.Serializable]
public class SaveList
{
    public List<SaveObject> saveData;
}

