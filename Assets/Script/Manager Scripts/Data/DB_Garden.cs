using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB_Garden : MonoBehaviour
{
    public bool firstTimeLoad = false;

    //string that defines planted seeds ex. (0.0.1.2.1) 
    //0 means no plants, 1 means coffee seed planted, 2 means tea seed planted
    public string plantType;
   
    //timer left in form of seconds (max. 86400, min. 0)
    public float moisturizeCD_01;
    public float moisturizeCD_02;
    public float moisturizeCD_03;
    public float moisturizeCD_04;
    public float moisturizeCD_05;

    //growth level or the amount of times a plant has been watered (max. 3, min, 0)
    public int growthLevel_01;
    public int growthLevel_02;
    public int growthLevel_03;
    public int growthLevel_04;
    public int growthLevel_05;

    #region savedata functions
    //done
    [ContextMenu("Garden_Save")]
    public void _OnSaveData_Garden()
    {
        SaveSystem.SaveData_Garden(this);
    }

    //done, not tested
    [ContextMenu("Garden_Load")]
    public void _OnLoadData_Garden()
    {
        SavedData_Garden savedData_Garden = SaveSystem.LoadData_Garden();

        plantType = savedData_Garden.plantType;

        moisturizeCD_01 = savedData_Garden.moisturizeCD_01;
        moisturizeCD_02 = savedData_Garden.moisturizeCD_02;
        moisturizeCD_03 = savedData_Garden.moisturizeCD_03;
        moisturizeCD_04 = savedData_Garden.moisturizeCD_04;
        moisturizeCD_05 = savedData_Garden.moisturizeCD_05;

        growthLevel_01 = savedData_Garden.growthLevel_01;
        growthLevel_02 = savedData_Garden.growthLevel_02;
        growthLevel_03 = savedData_Garden.growthLevel_03;
        growthLevel_04 = savedData_Garden.growthLevel_04;
        growthLevel_05 = savedData_Garden.growthLevel_05;
    }
    #endregion

    public static DB_Garden instance;

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

    void Start()
    {
        _OnLoadData_Garden();
    }

  
}
