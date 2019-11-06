﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavedData_Records
{
    
    public int couponsMade;
    public int spinCount;
    public string unlockedDrinks;
    public string unlockedIngredients;

    public SavedData_Records(DB_Records dbr) 
    {
        couponsMade = dbr.couponsMade;
        spinCount = dbr.spinCount;
        unlockedDrinks = dbr.unlockedDrinks;
        unlockedIngredients = dbr.unlockedIngredients;

    }
}
