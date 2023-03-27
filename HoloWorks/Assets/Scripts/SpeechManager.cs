using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Windows.Speech;
using System.Linq;
using System.Threading.Tasks;

public class SpeechManager : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    public GameObject info, video, safety, picture, ar, panel;

    private void Start()
    {
        keywordRecognizer = null;

        //Create keywords for keyword recognizer
        keywords.Add("bild", () =>
        {
            ToggleActive(picture);
        });

        keywords.Add("info", () =>
        {
            ToggleActive(info);
        });

        keywords.Add("video", () =>
        {
            ToggleActive(video);
        });

        keywords.Add("sicherheit", () =>
        {
            ToggleActive(safety);
        });

        keywords.Add("position", () =>
        {
            ToggleActive(ar);
        });

        keywords.Add("weiter", () =>
        {
            panel.GetComponent<WorkStep>().NextStep();
        });

        keywords.Add("zurück", () =>
        {
            panel.GetComponent<WorkStep>().PreviousStep();
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

    private void ToggleActive(GameObject element)
    {
        //get current active sate of gameobject
        bool isActive = element.activeSelf;

        //set the different active state
        element.SetActive(!isActive);
    }
}
