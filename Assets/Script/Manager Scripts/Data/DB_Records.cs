using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB_Records : MonoBehaviour
{
    public int couponsMade;
    public int spinCount;
    public string unlockedDrinks;
    public string unlockedIngredients;


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
        unlockedDrinks = savedData_Records.unlockedDrinks;
        unlockedIngredients = savedData_Records.unlockedIngredients;
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
        DontDestroyOnLoad(gameObject);
    }

}
