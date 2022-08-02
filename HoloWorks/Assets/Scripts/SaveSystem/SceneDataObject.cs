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
    public GameObject[] dataManagers;

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
}



[System.Serializable]
public class SaveList
{
    public List<SaveObject> saveData;
}

