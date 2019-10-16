using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeCounter : MonoBehaviour
{
    DB_General dbg;
    public TextMeshProUGUI timerDisplay;
    private float miliSecond;
    private string minute = "";
    private string second = "";
    public bool timerIsOn = true;


    public float startTime;
    public float minutes;
    public float seconds;
    public bool timerStart;
    public bool timerFinished;

    void Start()
    {
        dbg = FindObjectOfType<DB_General>();
        startTime *= 60;
        miliSecond = Time.time;
    }

    //void FixedUpdate()
    //{
    //    if (timerIsOn == true)
    //    {
    //        float t = Time.time - miliSecond;
    //        minute = ((int)t / 60).ToString();
    //        second = (t % 60).ToString("f2");

    //        //add a control statement here 
    //        //when minute is still below 10, add '0' in front
    //        timerDisplay.text = minute + ":" + second;
    //    }
    //}

    void FixedUpdate()
    {
        if (timerStart == true)
        {
            minutes = startTime / 60;
            seconds = startTime % 60;
            if (seconds < 10)
            {
                timerDisplay.text = ((int)minutes) + ":0" + ((int)seconds);
            }
            else
            {

                timerDisplay.text = ((int)minutes) + ":" + ((int)seconds);
            }
            startTime -= Time.deltaTime;
            if (minutes <= 0 && seconds <= 0)
            {
                timerFinished = true;
                StopTimer();
                timerDisplay.text = "0:00";
                dbg._15MinPassed = true;
            }
        }
    }

    public void StartTimer()
    {
        startTime = 15 * 60;
        timerFinished = false;
        timerStart = true;
    }


    public void StopTimer()
    {
        timerStart = false;
    }
}
