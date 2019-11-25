using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB_Records : MonoBehaviour
{
    public int couponsMade;
    public int spinCount;
    public int moisturizeCount;
    public int harvestCount;
    public int nameGuessCount;
    public string unlockedDrinks;
    public string unlockedIngredients;
    public string unlockedAchievements;


    [ContextMenu("Record_Save")]
    public void _OnSaveData_Records()
    {
        SaveSystem.SaveData_Record(this);
    }

    [ContextMenu("Record_Load")]
    public void _OnLoadData_Records()
    {
        SavedData_Records savedData_Records = SaveSystem.LoadData_Records();
        couponsMade = savedData_Records.couponsMade;
        spinCount = savedData_Records.spinCount;
        moisturizeCount = savedData_Records.moisturizeCount;
        harvestCount = savedData_Records.harvestCount;
        nameGuessCount = savedData_Records.nameGuessCount;

        unlockedDrinks = savedData_Records.unlockedDrinks;
        unlockedIngredients = savedData_Records.unlockedIngredients;
        unlockedAchievements = savedData_Records.unlockedAchievements;
    }


    public static DB_Records instance;

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
        transform.parent = null;
        DontDestroyOnLoad(gameObject);
    }

}
