using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerTimeManager : MonoBehaviour
{
    /* 
          necessary variables to hold all the things we need.
        php url
        timedata, the data we get back
        current time
        current date
    */

    public static ServerTimeManager sharedInstance = null;
    private string _url = "http://leatonm.net/wp-content/uploads/2017/candlepin/getdate.php";
    private string _timeData;

    DB_General dbg;
    PlantTimer pt;

    //make sure there is only one instance of this always.
    void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        else if (sharedInstance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    //time fether coroutine
    public IEnumerator getTime()
    {
        Debug.Log("==> step 1. Getting info from internet now!");
        WWW www = new WWW(_url);
        yield return www;
        Debug.Log("==> step 2. Got the info from internet!");
        _timeData = www.text;
        string[] words = _timeData.Split('/');
        string[] MMDDYYYY = words[0].Split('-');
        string[] HHMMSS = words[1].Split(':');
        //timerTestLabel.text = www.text;

        //these variables are still in string form
        Debug.Log("The date is : " + words[0]);
        Debug.Log("The time is : " + words[1]);
        Debug.Log("Date : " + MMDDYYYY[1]);
        Debug.Log("Month : " + MMDDYYYY[0]);
        Debug.Log("Year : " + MMDDYYYY[2]);
        Debug.Log("Hour : " + HHMMSS[0]);
        Debug.Log("Minute : " + HHMMSS[1]);
        Debug.Log("Second : " + HHMMSS[2]);


        //change US/eastern time to Asia/Jakarta time
        //changing the variables to int
        int easternUS_Hour = int.Parse(HHMMSS[0]);
        int jakartaAsia_Hour = easternUS_Hour + 11;
        int minute = int.Parse(HHMMSS[1]);
        int second = int.Parse(HHMMSS[2]);
        int date = int.Parse(MMDDYYYY[1]);
        int month = int.Parse(MMDDYYYY[0]);
        int year = int.Parse(MMDDYYYY[2]);
        if(jakartaAsia_Hour > 23){
            jakartaAsia_Hour -= 24;
            #region add date
            switch (month) { 
                case 1:
                    if (date == 31)
                    {
                        month++;
                        date = 1;
                    }
                    else 
                    {
                        date++;
                    }
                    break;
                case 2:
                    if (year % 4 == 0)
                    {
                        if (date == 29) 
                        {
                            month++;
                            date = 1;
                        }
                        else
                        {
                            date++;
                        }
                    }
                    else
                    {
                        if (date == 28)
                        {
                            month++;
                            date = 1;
                        }
                        else
                        {
                            date++;
                        }
                    }
                    break;
                case 3:
                    if (date == 31)
                    {
                        month++;
                        date = 1;
                    }
                    else
                    {
                        date++;
                    }
                    break;
                case 4:
                    if (date == 30)
                    {
                        month++;
                        date = 1;
                    }
                    else
                    {
                        date++;
                    }
                    break;
                case 5:
                    if (date == 31)
                    {
                        month++;
                        date = 1;
                    }
                    else
                    {
                        date++;
                    }
                    break;
                case 6:
                    if (date == 30)
                    {
                        month++;
                        date = 1;
                    }
                    else
                    {
                        date++;
                    }
                    break;
                case 7:
                    if (date == 31)
                    {
                        month++;
                        date = 1;
                    }
                    else
                    {
                        date++;
                    }
                    break;
                case 8:
                    if (date == 31)
                    {
                        month++;
                        date = 1;
                    }
                    else
                    {
                        date++;
                    }
                    break;
                case 9:
                    if (date == 30)
                    {
                        month++;
                        date = 1;
                    }
                    else
                    {
                        date++;
                    }
                    break;
                case 10:
                    if (date == 31)
                    {
                        month++;
                        date = 1;
                    }
                    else
                    {
                        date++;
                    }
                    break;
                case 11:
                    if (date == 30)
                    {
                        month++;
                        date = 1;
                    }
                    else
                    {
                        date++;
                    }
                    break;
                case 12:
                    if (date == 31)
                    {
                        month = 1;
                        date = 1;
                    }
                    else
                    {
                        date++;
                    }
                    break;
            }
            #endregion
        }
        Debug.Log("Current time is : " + jakartaAsia_Hour + ":" + minute + ":" + second);
        Debug.Log("Current date is : " + date + "-" + month + "-" + year);
        dbg.getHour = jakartaAsia_Hour;
        dbg.getMinute = minute;
        dbg.getSecond = second;
        dbg.getDate = date;
        dbg.getMonth = month;
        dbg.getYear = year;


        dbg._OnLoadData_General();
        dbg.GetTimePassed();
        pt.ReduceMoistCooldown();
    }

    void Start()
    {
        dbg = FindObjectOfType<DB_General>();
        pt = FindObjectOfType<PlantTimer>();
        StartCoroutine("getTime");
    }

}