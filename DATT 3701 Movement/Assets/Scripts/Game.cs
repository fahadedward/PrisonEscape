using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Game : MonoBehaviour
{

    [SerializeField]
    float startTime = 600f, currentTime, currentSeconds = 60f;
   // double currSeconds = 59.9;
    [SerializeField]
    Text p1minuteText, p1secondText;
    float temp = 10f;
    float seconds;
    [SerializeField]
    AudioSource BGM;
    void Start()
    {
        currentTime = startTime;
        BGM.Play();
    }

    // Update is called once per frame
    void Update()
    {
       
        currentSeconds -= 1 * Time.deltaTime;
        if (currentSeconds <= 0)
        {
            currentSeconds = 59.9f;
        }
        currentTime -= 1 * Time.deltaTime;
        float currentTimeInMinutes = TimeSpan.FromSeconds(currentTime).Minutes;
        seconds = Mathf.RoundToInt(currentSeconds);
        p1minuteText.text = "Time " + currentTimeInMinutes.ToString() + ":";
        p1secondText.text = seconds.ToString();
        if (currentTime <= 0)
        {
            print("Scientist win");
            GameManager.instance.ScientistWin();
        }

        if(currentTime < 120)
        {
            p1minuteText.color = new Color(1f, 0f, 0f, 1f);
            p1secondText.color = new Color(1f, 0f, 0f, 1f);
        }
       
    }
}

