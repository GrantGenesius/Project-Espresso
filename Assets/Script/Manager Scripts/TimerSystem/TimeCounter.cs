using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeCounter : MonoBehaviour
{
    public TextMeshProUGUI timerDisplay;
    public TextMeshProUGUI timerNotification;
    public RotatingBehaviour rotatingBehaviour;
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
        StopTimer();
        //startTime *= 60;
        //miliSecond = Time.time;
        //StartTimer();
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
                DB_General.instance._15MinPassed = true;
            }
        }
    }

    [ContextMenu("Start Timer")]
    public void StartTimer()
    {
        startTime = 15 * 60;
        timerFinished = false;
        timerStart = true;
        timerNotification.text = "COOLDOWN";
        rotatingBehaviour.trueCooldown = false;
        //rotatingBehaviour.spinCDAvailable = false;
    }


    [ContextMenu("Stop Timer")]
    public void StopTimer()
    {
        timerStart = false;
        startTime = 0;
        timerDisplay.text = "0:00";
        timerNotification.text = "SPIN AVAILABLE";
        rotatingBehaviour.trueCooldown = true;
        //rotatingBehaviour.spinCDAvailable = true;
    }
}
