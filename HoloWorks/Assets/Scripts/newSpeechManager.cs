using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Windows.Speech;
using System.Linq;
using System.Threading.Tasks;

public class newSpeechManager : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    public GameObject anchor;

    private void Start()
    {
        //Create keywords for keyword recognizer
        keywords.Add("bild", () =>
        {
            Debug.Log("Sprachbefehl Bild anzeigen");
            ToggleActive("Picture");
        });


        keywords.Add("info", () =>
        {
            ToggleActive("Info");
        });

        keywords.Add("video", () =>
        {
            Debug.Log("Sprachbefehl Video anzeigen");
            ToggleActive("Video");
        });

        keywords.Add("sicherheit", () =>
        {
            ToggleActive("Safety");
        });

        keywords.Add("a air", () =>
        {
            for (int i = 0; i < anchor.transform.childCount; i++)
            {
                GameObject Go = anchor.transform.GetChild(i).gameObject;

                if (Go.activeSelf == true)
                {
                    Debug.Log(Go.name);
                    GameObject media = Go.transform.Find("3D Elements").Find("AR Elements").gameObject;
                    media.SetActive(!media.activeSelf);
                }

                GameObject button = Go.transform.Find("InstructionUI").Find("ButtonMediatypes").Find("PressableButtonHoloLens2Bar5H(Clone)").Find("ButtonCollection").Find("Button AR").Find("BackPlateToggleState").gameObject;
                button.SetActive(!button.activeSelf);
            }
        });

        keywords.Add("weiter", () =>
        {
            for (int i = 0; i < anchor.transform.childCount; i++)
            {
                GameObject Go = anchor.transform.GetChild(i).gameObject;

                if (Go.activeSelf == true)
                {
                    Debug.Log(Go.name);
                    Go.transform.Find("InstructionUI").GetComponent<WorkStep>().NextStep();
                }
            }
        });

        keywords.Add("zurück", () =>
        {
            for (int i = 0; i < anchor.transform.childCount; i++)
            {
                GameObject Go = anchor.transform.GetChild(i).gameObject;

                if (Go.activeSelf == true)
                {
                    Debug.Log(Go.name);
                    Go.transform.Find("InstructionUI").GetComponent<WorkStep>().PreviousStep();
                }
            }
        });

        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;

        keywordRecognizer.Start();

        Debug.Log("-------- keywordRecognizer started --------");

        
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        // if the keyword recognized is in our dictionary, call that Action.
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }

    private void ToggleActive(string mediatype)
    {
        for (int i = 0; i < anchor.transform.childCount; i++)
        {
            GameObject Go = anchor.transform.GetChild(i).gameObject;

            if (Go.activeSelf == true)
            {
                Debug.Log(Go.name);
                GameObject media = Go.transform.Find("InstructionUI").Find("Mediatypes").Find(mediatype).gameObject;
                media.SetActive(!media.activeSelf);

                GameObject button = Go.transform.Find("InstructionUI").Find("ButtonMediatypes").Find("PressableButtonHoloLens2Bar5H(Clone)").Find("ButtonCollection").Find("Button " + mediatype).Find("BackPlateToggleState").gameObject;
                button.SetActive(!button.activeSelf);
            }
        }
    }
}

