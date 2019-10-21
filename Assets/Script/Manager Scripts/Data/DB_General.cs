using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB_General : MonoBehaviour
{

    [Header("Old/Saved serverTime")]
    [Range(0, 23)]
    public int hour;
    [Range(0, 59)]
    public int minute;
    [Range(0, 59)]
    public int second;
    [Range(0, 31)]
    public int date;
    [Range(0, 12)]
    public int month;
    [Range(0, 2200)]
    public int year;

    [Header("New/Fresh serverTime")]
    [Range(0, 23)]
    public int getHour;
    [Range(0, 59)]
    public int getMinute;
    [Range(0, 59)]
    public int getSecond;
    [Range(0, 31)]
    public int getDate;
    [Range(0, 12)]
    public int getMonth;
    [Range(0, 2200)]
    public int getYear;

    [Header("Time Difference")]
    public bool _15MinPassed;
    public bool _24HrsPassed;
    public int hourPassed;
    public int minutePassed;
    public int secondPassed;
    public int datePassed;
    public int monthPassed;
    public int yearPassed;

    [ContextMenu("Count_TimePassed")]
    public void GetTimePassed() {
        _15MinPassed = false;
        _24HrsPassed = false;
        //check for date difference, dayPassed, and oneDayDifference
        bool dayHasPassed = false;
        bool oneDayDifference = false;
        if (date == getDate && month == getMonth && year == getYear)
        {
            dayHasPassed = false;
            oneDayDifference = false;
        }
        else {
            if (year + 1 == getYear &&
                month == 12 && getMonth == 1 &&
                date == 31 && getDate == 1)
            {
                oneDayDifference = true;
            } 
            else if (month != getMonth)
            {
                if (month + 1 == getMonth)
                {
                    if (getDate == 1)
                    {   
                        #region check for oneDayDifference if month difference is 1 using SWITCH CASE statement
                        switch (month)
                        {
                            case 1:
                                if (date == 31)
                                    oneDayDifference = true;
                                else
                                    _24HrsPassed = true;
                                break;
                            case 2:
                                if (year % 4 == 0)
                                {
                                    if (date == 29)
                                        oneDayDifference = true;
                                    else
                                        _24HrsPassed = true;
                                }
                                else if (date == 28)
                                    oneDayDifference = true;
                                else
                                    _24HrsPassed = true;
                                break;
                            case 3:
                                if (date == 31)
                                    oneDayDifference = true;
                                else
                                    _24HrsPassed = true;
                                break;
                            case 4:
                                if (date == 30)
                                    oneDayDifference = true;
                                else
                                    _24HrsPassed = true;
                                break;
                            case 5:
                                if (date == 31)
                                    oneDayDifference = true;
                                else
                                    _24HrsPassed = true;
                                break;
                            case 6:
                                if (date == 30)
                                    oneDayDifference = true;
                                else
                                    _24HrsPassed = true;
                                break;
                            case 7:
                                if (date == 31)
                                    oneDayDifference = true;
                                else
                                    _24HrsPassed = true;
                                break;
                            case 8:
                                if (date == 31)
                                    oneDayDifference = true;
                                else
                                    _24HrsPassed = true;
                                break;
                            case 9:
                                if (date == 30)
                                    oneDayDifference = true;
                                else
                                    _24HrsPassed = true;
                                break;
                            case 10:
                                if (date == 31)
                                    oneDayDifference = true;
                                else
                                    _24HrsPassed = true;
                                break;
                            case 11:
                                if (date == 30)
                                    oneDayDifference = true;
                                else
                                    _24HrsPassed = true;
                                break;
                        }
                        #endregion
                    }
                }
            }
            else if(date + 1 == getDate)
            {
                oneDayDifference = true;
            }
            else 
            {
                oneDayDifference = false;
                dayHasPassed = true;
                _15MinPassed = true;
                _24HrsPassed = true;
            }
        }

        //measure time difference
        if (dayHasPassed == false)
        {
            if (oneDayDifference == true)
            {
                //different day, but only the day before
                hourPassed = (23 - hour) + getHour;
                minutePassed = (59 - minute) + getMinute;
                secondPassed = (59 - second) + getSecond;

                minutePassed += (secondPassed / 60);
                if(secondPassed > 59)
                    secondPassed -= 60;
                hourPassed += (minutePassed / 60);
                if(minutePassed > 59)
                    minutePassed -= 60;
                if (hourPassed > 23) {
                    _24HrsPassed = true;
                    dayHasPassed = true;
                }
            }
            else if(oneDayDifference == false)
            {
                //same day
                hourPassed = getHour - hour;
                minutePassed = getMinute - minute;
                secondPassed = getSecond - second;
                
            }
        }
        else { 
            //more than 24 hrs had already passed, so time difference doesnt really matters
            //spinCD
            //PlantGrowth
            _15MinPassed = true;
            _24HrsPassed = true;
        }
        if (hourPassed > 0)
            _15MinPassed = true;
        if (minutePassed > 15)
            _15MinPassed = true; if (secondPassed < 0)
        {
            minutePassed--;
            secondPassed += 60;
        }
        if (minutePassed < 0)
        {
            hourPassed--;
            minutePassed += 60;
        }
        datePassed = hourPassed / 24;
        monthPassed = datePassed / 30;
        yearPassed = monthPassed / 12;
    }

    #region savedata functions
    //done
    [ContextMenu("General_Save")]
    public void _OnSaveData_General()
    {
        SaveSystem.SaveData_General(this);
    }

    //done, not tested
    [ContextMenu("General_Load")]
    public void _OnLoadData_General()
    {
        SavedData_General savedData_General = SaveSystem.LoadData_General();
        hour = savedData_General.hour;
        minute = savedData_General.minute;
        second = savedData_General.second;
        date = savedData_General.date;
        month = savedData_General.month;
        year = savedData_General.year;
    }
    #endregion


    public static DB_General instance;

    //singleton code here
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start() {
        _OnLoadData_General();
    }
}
