using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{

    public float currentTime = 0f;
    public float startingTime = 3f;
    public Text countDownText;
    public GameObject countDownGo;

    // Start is called before the first frame update
    void Awake()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countDownText.text = currentTime.ToString("0");
        if(currentTime <= 0)
        {
            currentTime = 0;
            Destroy(countDownGo);
        }
    }
}
