using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuthorTabBar : MonoBehaviour
{
    public GameObject Tabs;

    private void Start()
    {
        int tabCount = Tabs.transform.childCount;

        for (int i = 0; i < tabCount; i++)
        {
            Tabs.transform.GetChild(i).gameObject.SetActive(true);
            Tabs.transform.GetChild(i).gameObject.SetActive(false);
        }

        Tabs.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void ChangeTab(string pressedButton)
    {
        int tabCount = Tabs.transform.childCount;

        for (int i = 0; i < tabCount; i++)
        {
            Tabs.transform.GetChild(i).gameObject.SetActive(false);
        }

        Tabs.transform.Find(pressedButton).gameObject.SetActive(true);
    }
}
