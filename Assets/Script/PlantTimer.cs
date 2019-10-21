using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantTimer : MonoBehaviour
{
    
    public bool[] timerHasStarted;
    public GameObject[] allGround;

    public bool timerIsOn = true;


    public float[] moisturizesCooldown;
    public float[] minutes;
    public float[] seconds;
    public float[] hour;

    public bool timerStart;
    public bool timerFinished;


    void Start()
    {
        
    }

    void FixedUpdate()
    {
        for(int i = 0; i<moisturizesCooldown.Length; i++)
        {
            if (moisturizesCooldown[i] >= 0)
            {
                TimeDisplay(i);
            }
        }
        for (int i = 0; i < timerHasStarted.Length; i++)
        {
            if (timerHasStarted[i] == true)
            {
                //reduce time here
                moisturizesCooldown[i] -= Time.deltaTime;
            }
            if (moisturizesCooldown[i] <= 0)
            {
                timerHasStarted[i] = false;
                moisturizesCooldown[i] = 0;
            }
        }
    }

    //public void StartTimer()
    //{
    //    startTime = 15 * 60;
    //    timerFinished = false;
    //    timerStart = true;
    //}


    public void StopTimer(int index)
    {
        timerHasStarted[index] = false;
        moisturizesCooldown[index] = 0;
    }

    public void TimeDisplay(int idx)
    {
        hour[idx] = moisturizesCooldown[idx] / 3600;
        minutes[idx] = (moisturizesCooldown[idx] % 3600)/60;

        seconds[idx] = moisturizesCooldown[idx] % 60;
        
    }


}
