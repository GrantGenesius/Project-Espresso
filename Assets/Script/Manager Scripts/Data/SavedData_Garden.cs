using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavedData_Garden
{
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

    public SavedData_Garden(DB_Garden dbga) 
    {
        plantType = dbga.plantType;

        moisturizeCD_01 = dbga.moisturizeCD_01;
        moisturizeCD_02 = dbga.moisturizeCD_02;
        moisturizeCD_03 = dbga.moisturizeCD_03;
        moisturizeCD_04 = dbga.moisturizeCD_04;
        moisturizeCD_05 = dbga.moisturizeCD_05;

        growthLevel_01 = dbga.growthLevel_01;
        growthLevel_02 = dbga.growthLevel_02;
        growthLevel_03 = dbga.growthLevel_03;
        growthLevel_04 = dbga.growthLevel_04;
        growthLevel_05 = dbga.growthLevel_05;
    }
}
