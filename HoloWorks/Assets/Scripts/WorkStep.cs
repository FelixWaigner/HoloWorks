using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkStep : MonoBehaviour
{
    public void CreateNewWorkStep()
    {
        GameObject instruction = Instantiate(Resources.Load<GameObject>("Prefabs/UI/UI"));

        GameObject anchor = GameObject.FindWithTag("Anchor");

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

    /*public void NextStep()
    {
        GameObject workstep = gameObject.transform.parent.gameObject;
        GameObject anchor = GameObject.FindWithTag("Anchor");

        if (workstep.transform.GetSiblingIndex() != anchor.transform.childCount)
        {
            anchor.transform.GetChild(workstep.transform.GetSiblingIndex()).gameObject.SetActive(false);
            anchor.transform.GetChild(workstep.transform.GetSiblingIndex() + 1).gameObject.SetActive(true);
        }
    }*/

    /*public void PreviousStep()
    {
        GameObject workstep = gameObject.transform.parent.gameObject;
        GameObject anchor = GameObject.FindWithTag("Anchor");

        if (workstep.transform.GetSiblingIndex() != 0)
        {

            anchor.transform.GetChild(workstep.transform.GetSiblingIndex()).gameObject.SetActive(false);
            anchor.transform.GetChild(workstep.transform.GetSiblingIndex() - 1).gameObject.SetActive(true);
        }
    }*/
}
