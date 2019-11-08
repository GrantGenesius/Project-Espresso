using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavedData_Records
{
    
    public int couponsMade;
    public int spinCount;
    public int moisturizeCount;
    public int harvestCount;
    public int nameGuessCount;
    public string unlockedDrinks;
    public string unlockedIngredients;
    public string unlockedAchievements;

    public SavedData_Records(DB_Records dbr) 
    {
        couponsMade = dbr.couponsMade;
        spinCount = dbr.spinCount;
        moisturizeCount = dbr.moisturizeCount;
        harvestCount = dbr.harvestCount;
        nameGuessCount = dbr.nameGuessCount;

        unlockedDrinks = dbr.unlockedDrinks;
        unlockedIngredients = dbr.unlockedIngredients;
        unlockedAchievements = dbr.unlockedAchievements;

    }
}
