using Microsoft.MixedReality.Toolkit.Examples.Demos;
using Microsoft.MixedReality.Toolkit.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class SceneDataObject : MonoBehaviour
{
    public GameObject anchor;
    public SaveList saveObjects = new SaveList();

    private string currentStep;

    public void init(GameObject target)
    {
        target.SetActive(false);

        var fp = GameObject.Find("TraineeTrainerManager").GetComponent<TraineeTrainerManager>();
        if (fp.filePath != "")
        {
            loadData(fp.filePath);
        }
    }

    public void loadData(string filePath)
    {
        saveObjects = SaveManager.Load(filePath);

        Debug.Log(filePath);

        foreach (Transform child in anchor.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (SaveObject obj in saveObjects.saveData)
        {
            GameObject UiObject = Instantiate(Resources.Load<GameObject>("Prefabs/UI/UI"), anchor.transform);
            //UiObject.transform.SetParent(anchor.transform);
            //UiObject.transform.position = new Vector3(0, 0, 0);
            UiObject.name = obj.id;

            //Add Title
            if (obj.Title != "")
            {
                UiObject.transform.Find("InstructionUI").Find("UITextSelawikSemibold").Find("InstructionText").GetComponent<Text>().text = obj.Title;
            }

            //Add Description
            if (obj.Info != "")
            {
                UiObject.transform.Find("OptionsHandMenu").Find("MenuContent").Find("Tabs").Find("Info").gameObject.SetActive(true);
                UiObject.transform.Find("OptionsHandMenu").Find("MenuContent").Find("Tabs").Find("Info").GetComponent<AuthorToggleActive>().setToggleActive();
                UiObject.transform.Find("OptionsHandMenu").Find("MenuContent").Find("Tabs").Find("Info").gameObject.SetActive(false);

                UiObject.transform.Find("InstructionUI").Find("Mediatypes").Find("Info").Find("InfoText").Find("DescriptionText").GetComponent<Text>().text = obj.Info;
            }
            else
            {
                UiObject.transform.Find("OptionsHandMenu").Find("MenuContent").Find("Tabs").Find("Info").gameObject.SetActive(true);
                UiObject.transform.Find("OptionsHandMenu").Find("MenuContent").Find("Tabs").Find("Info").GetComponent<AuthorToggleActive>().setToggleDisabled();
                UiObject.transform.Find("OptionsHandMenu").Find("MenuContent").Find("Tabs").Find("Info").gameObject.SetActive(false);
            }

            //Add Savety
            if (obj.Security != "")
            {
                UiObject.transform.Find("OptionsHandMenu").Find("MenuContent").Find("Tabs").Find("Safety").gameObject.SetActive(true);
                UiObject.transform.Find("OptionsHandMenu").Find("MenuContent").Find("Tabs").Find("Safety").GetComponent<AuthorToggleActive>().setToggleActive();
                UiObject.transform.Find("OptionsHandMenu").Find("MenuContent").Find("Tabs").Find("Safety").gameObject.SetActive(false);

                UiObject.transform.Find("InstructionUI").Find("Mediatypes").Find("Safety").Find("SavetyText").Find("SafetyText").GetComponent<Text>().text = obj.Security;
            }
            else
            {
                UiObject.transform.Find("OptionsHandMenu").Find("MenuContent").Find("Tabs").Find("Safety").gameObject.SetActive(true);
                UiObject.transform.Find("OptionsHandMenu").Find("MenuContent").Find("Tabs").Find("Safety").GetComponent<AuthorToggleActive>().setToggleDisabled();
                UiObject.transform.Find("OptionsHandMenu").Find("MenuContent").Find("Tabs").Find("Safety").gameObject.SetActive(false);
            }

            //Add Video
            if (obj.Video != "")
            {
                UiObject.transform.Find("OptionsHandMenu").Find("MenuContent").Find("Tabs").Find("Video").gameObject.SetActive(true);
                UiObject.transform.Find("OptionsHandMenu").Find("MenuContent").Find("Tabs").Find("Video").GetComponent<AuthorToggleActive>().setToggleActive();
                UiObject.transform.Find("OptionsHandMenu").Find("MenuContent").Find("Tabs").Find("Video").gameObject.SetActive(false);

                var updateVideo = UiObject.transform.Find("InstructionUI").Find("Mediatypes").Find("Video").Find("VideoContainer").Find("Video Player").GetComponent<VideoPlayer>();
                updateVideo.url = obj.Video;

            }
            else
            {
                UiObject.transform.Find("OptionsHandMenu").Find("MenuContent").Find("Tabs").Find("Video").gameObject.SetActive(true);
                UiObject.transform.Find("OptionsHandMenu").Find("MenuContent").Find("Tabs").Find("Video").GetComponent<AuthorToggleActive>().setToggleDisabled();
                UiObject.transform.Find("OptionsHandMenu").Find("MenuContent").Find("Tabs").Find("Video").gameObject.SetActive(false);
            }

            //Add Picture
            if (obj.Image != "")
            {
                UiObject.transform.Find("OptionsHandMenu").Find("MenuContent").Find("Tabs").Find("Picture").gameObject.SetActive(true);
                UiObject.transform.Find("OptionsHandMenu").Find("MenuContent").Find("Tabs").Find("Picture").GetComponent<AuthorToggleActive>().setToggleActive();
                UiObject.transform.Find("OptionsHandMenu").Find("MenuContent").Find("Tabs").Find("Picture").gameObject.SetActive(false);

                var updatePicture = UiObject.transform.Find("OptionsHandMenu").Find("PhotoManager").GetComponent<PhotoCaptureExample>();
                updatePicture.filePath = obj.Image;
                updatePicture.LoadImage(obj.Image);
            }
            else
            {
                UiObject.transform.Find("OptionsHandMenu").Find("MenuContent").Find("Tabs").Find("Picture").gameObject.SetActive(true);
                UiObject.transform.Find("OptionsHandMenu").Find("MenuContent").Find("Tabs").Find("Picture").GetComponent<AuthorToggleActive>().setToggleDisabled();
                UiObject.transform.Find("OptionsHandMenu").Find("MenuContent").Find("Tabs").Find("Picture").gameObject.SetActive(false);
            }

            //Add element
            if (obj.Elements.Count > 0)
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
                    newArObj.transform.GetChild(0).localRotation = Quaternion.Euler(rot);

                    Vector3 scale;
                    scale.x = element.scale[0];
                    scale.y = element.scale[1];
                    scale.z = element.scale[2];
                    newArObj.transform.GetChild(0).localScale = scale;
                }
            }
            else
            {
                UiObject.transform.Find("OptionsHandMenu").Find("MenuContent").Find("Tabs").Find("AR").gameObject.SetActive(true);
                UiObject.transform.Find("OptionsHandMenu").Find("MenuContent").Find("Tabs").Find("AR").GetComponent<AuthorToggleActive>().setToggleDisabled();
                UiObject.transform.Find("OptionsHandMenu").Find("MenuContent").Find("Tabs").Find("AR").gameObject.SetActive(false);
            }

            var UiDataManager = UiObject.transform.Find("InstructionUI").Find("DataManager").gameObject.GetComponent<UIData>();
            UiDataManager.Title = obj.Title;
            UiDataManager.Info = obj.Info;
            UiDataManager.Security = obj.Security;
            UiDataManager.Image = obj.Image;
            UiDataManager.Video = obj.Video;


            if (GameObject.FindGameObjectWithTag("TrainingNameManager").GetComponent<TraineeTrainerManager>().user == "Trainer")
            {
                if (obj.Info != "")
                {
                    UiObject.transform.Find("OptionsHandMenu").Find("MenuContent").Find("Tabs").Find("Info").GetComponent<AuthorToggleActive>().setAutorToggleActive();
                }

                if (obj.Security != "")
                {
                    UiObject.transform.Find("OptionsHandMenu").Find("MenuContent").Find("Tabs").Find("Safety").GetComponent<AuthorToggleActive>().setAutorToggleActive();
                }

                if (obj.Video != "")
                {
                    GameObject videoObj = UiObject.transform.Find("InstructionUI").Find("Mediatypes").Find("Video").gameObject;
                    videoObj.SetActive(true);
                    videoObj.GetComponent<VideoPlayer>().playOnAwake = false;
                    videoObj.transform.Find("VideoContainer").Find("Video Player").gameObject.GetComponent<VideoPlayer>().playOnAwake = false;
                    videoObj.SetActive(false);

                    UiObject.transform.Find("OptionsHandMenu").Find("MenuContent").Find("Tabs").Find("Video").GetComponent<AuthorToggleActive>().setAutorToggleActive();
                }

                if (obj.Image != "")
                {
                    UiObject.transform.Find("OptionsHandMenu").Find("MenuContent").Find("Tabs").Find("Picture").GetComponent<AuthorToggleActive>().setAutorToggleActive();
                }

                if (obj.Elements.Count > 0)
                {
                    UiObject.transform.Find("OptionsHandMenu").Find("MenuContent").Find("Tabs").Find("AR").GetComponent<AuthorToggleActive>().setAutorToggleActive();
                }

                if (UiObject.name != "0")
                {
                    UiObject.gameObject.SetActive(false);
                }
            }

            if (GameObject.FindGameObjectWithTag("TrainingNameManager").GetComponent<TraineeTrainerManager>().user == "Trainee")
            {
                foreach (Transform child in anchor.transform)
                {
                    GameObject arElements = child.Find("3D Elements").Find("AR Elements").gameObject;

                    foreach (Transform arElement in arElements.transform)
                    {
                        arElement.Find("Object").GetComponent<ManipulationHandler>().enabled = false;
                        arElement.Find("AppBar").gameObject.SetActive(false);
                    }
                }

                UiObject.transform.Find("OptionsHandMenu").gameObject.SetActive(false);

                if (UiObject.name != "0")
                {
                    UiObject.gameObject.SetActive(false);
                }
            }
        }

        Debug.Log("...LOAD...");
    }

    public void saveData()
    {
        saveObjects.saveData.Clear();

        foreach (Transform child in anchor.transform)
        {
            if (child.gameObject.activeSelf == true)
            {
                currentStep = child.name;
            }
            child.gameObject.SetActive(true);
        }

        foreach (Transform child in anchor.transform)
        {
            SaveObject data = new SaveObject();

            var dataClass = child.Find("InstructionUI").Find("DataManager").GetComponent<UIData>();
            dataClass.WriteUiData();
            data.id = child.name;
            data.Title = dataClass.Title;
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
            if (child.name != currentStep)
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    private void FindGameObjectsWithTag(string v)
    {
        throw new NotImplementedException();
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

