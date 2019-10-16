using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavedData_General
{
    public int hour;
    public int minute;
    public int second;
    public int date;
    public int month;
    public int year;

    public SavedData_General(DB_General dbg) 
    {
        hour = dbg.getHour;
        minute = dbg.getMinute;
        second = dbg.getSecond;
        date = dbg.getDate;
        month = dbg.getMonth;
        year = dbg.getYear;

    }
}
