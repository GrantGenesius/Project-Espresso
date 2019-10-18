using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantTimer : MonoBehaviour
{
    public float[] moisturizesCooldown;
    public bool[] timerHasStarted;
    public GameObject[] allGround;

    public bool timerIsOn = true;


    public float startTime;
    public float minutes;
    public float seconds;
    public bool timerStart;
    public bool timerFinished;


    void Start()
    {
        
    }

    void FixedUpdate()
    {
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

    public void StartTimer()
    {
        startTime = 15 * 60;
        timerFinished = false;
        timerStart = true;
    }


    public void StopTimer(int index)
    {
        timerHasStarted[index] = false;
        moisturizesCooldown[index] = 0;
    }


}
