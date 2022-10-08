using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkStep : MonoBehaviour
{
    public float x, y, z;

    public void SaveUIPosition(GameObject ws)
    {
        x = ws.transform.position.x;
        y = ws.transform.position.y;
        z = ws.transform.position.z;

        PlayerPrefs.SetFloat("x", x);
        PlayerPrefs.SetFloat("y", y);
        PlayerPrefs.SetFloat("z", z);
    }

    public void LoadUIPosition(GameObject ws)
    {
        x = PlayerPrefs.GetFloat("x");
        y = PlayerPrefs.GetFloat("y");
        z = PlayerPrefs.GetFloat("z");

        Vector3 LoadPosition = new Vector3(x, y, z);
        ws.transform.position = LoadPosition;
    }
    public void CreateNewWorkStep()
    {

        GameObject anchor = GameObject.FindWithTag("Anchor");
        GameObject instruction = Instantiate(Resources.Load<GameObject>("Prefabs/UI/UI"), anchor.transform);

        instruction.name = anchor.transform.childCount.ToString();

        for (int j = 0; j < anchor.transform.childCount; j++)
        {
            anchor.transform.GetChild(j).gameObject.SetActive(false);
        }

        instruction.transform.SetParent(anchor.transform);
    }

    public void DeleteWorkStep()
    {
        GameObject workstep = gameObject.transform.parent.gameObject;
        GameObject anchor = GameObject.FindWithTag("Anchor");

        if (workstep.transform.GetSiblingIndex() != 0)
        {
            //Activate the GameObject above the Destroyed GameObject
            anchor.transform.GetChild(workstep.transform.GetSiblingIndex() - 1).gameObject.SetActive(true);

            Destroy(workstep);
        }
    }

    public void NextStep()
    {
        GameObject workstep = gameObject.transform.parent.gameObject;
        GameObject anchor = GameObject.FindWithTag("Anchor");

        if (workstep.transform.GetSiblingIndex() != anchor.transform.childCount - 1)
        {
            SaveUIPosition(anchor.transform.GetChild(workstep.transform.GetSiblingIndex()).GetChild(1).gameObject);
            GameObject currentGO = anchor.transform.GetChild(workstep.transform.GetSiblingIndex()).gameObject;
            currentGO.SetActive(false);
            
            LoadUIPosition(anchor.transform.GetChild(workstep.transform.GetSiblingIndex() + 1).GetChild(1).gameObject);
            GameObject nextGO = anchor.transform.GetChild(workstep.transform.GetSiblingIndex() + 1).gameObject;
            nextGO.SetActive(true);
        }
    }

    public void PreviousStep()
    {
        GameObject workstep = gameObject.transform.parent.gameObject;
        GameObject anchor = GameObject.FindWithTag("Anchor");

        if (workstep.transform.GetSiblingIndex() != 0)
        {
            SaveUIPosition(anchor.transform.GetChild(workstep.transform.GetSiblingIndex()).GetChild(1).gameObject);
            anchor.transform.GetChild(workstep.transform.GetSiblingIndex()).gameObject.SetActive(false);
            LoadUIPosition(anchor.transform.GetChild(workstep.transform.GetSiblingIndex() - 1).GetChild(1).gameObject);
            anchor.transform.GetChild(workstep.transform.GetSiblingIndex() - 1).gameObject.SetActive(true);
        }
    }
}
