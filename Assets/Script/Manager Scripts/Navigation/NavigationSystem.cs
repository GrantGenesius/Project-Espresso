using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationSystem : MonoBehaviour
{
    public Animator anim;
    public BrewIngridientList bil;
    
    bool navigationActive;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void _OnOpenClose()
    {
        if (navigationActive)
        {
            anim.SetBool("Open", false);
            navigationActive = false;
        }
        else
        {
            anim.SetBool("Open", true);
            navigationActive = true;
        }
    }

    public void _OnSceneManagement(string levelName)
    {
        if (CheckScene() == "Garden")
            SaveGarden();
        SceneManager.LoadScene(levelName);
    }

    public string CheckScene()
    {
        Scene scene;
        string sceneName = "";
        scene = SceneManager.GetActiveScene();
        sceneName = scene.name;

        return sceneName;
    }

    public void _OnExperiment()
    {
        if(CheckScene() == "Brew")
        {
            bil.isExperimenting = true;
        }
    }

    public void _OnNotExperiment()
    {
        if (CheckScene() == "Brew")
        {
            bil.isExperimenting = false;
        }
    }

    void OnApplicationQuit()
    {
        SaveGarden();
    }

    public void LoadGarden() {
        PlantTimer pt = FindObjectOfType<PlantTimer>();
        DB_Garden dbga = FindObjectOfType<DB_Garden>();

        if (dbga.firstTimeLoad == false)
        {
            dbga._OnLoadData_Garden();

            pt.savedString = dbga.plantType;
            pt.ConvertStringtoPlantID();

            pt.waterLevel[0] = dbga.growthLevel_01;
            pt.waterLevel[1] = dbga.growthLevel_02;
            pt.waterLevel[2] = dbga.growthLevel_03;
            pt.waterLevel[3] = dbga.growthLevel_04;
            pt.waterLevel[4] = dbga.growthLevel_05;

            pt.moisturizesCooldown[0] = dbga.moisturizeCD_01;
            pt.moisturizesCooldown[1] = dbga.moisturizeCD_02;
            pt.moisturizesCooldown[2] = dbga.moisturizeCD_03;
            pt.moisturizesCooldown[3] = dbga.moisturizeCD_04;
            pt.moisturizesCooldown[4] = dbga.moisturizeCD_05;

            dbga.firstTimeLoad = true;
        }

    }

    public void SaveGarden()
    {
        PlantTimer pt = FindObjectOfType<PlantTimer>();
        DB_Garden dbga = FindObjectOfType<DB_Garden>();

        pt.ResetPlantType();
        pt.MergePlantIDList();
        dbga.plantType = pt.savedString;

        dbga.moisturizeCD_01 = pt.moisturizesCooldown[0];
        dbga.moisturizeCD_02 = pt.moisturizesCooldown[1];
        dbga.moisturizeCD_03 = pt.moisturizesCooldown[2];
        dbga.moisturizeCD_04 = pt.moisturizesCooldown[3];
        dbga.moisturizeCD_05 = pt.moisturizesCooldown[4];

        dbga.growthLevel_01 = pt.waterLevel[0];
        dbga.growthLevel_02 = pt.waterLevel[1];
        dbga.growthLevel_03 = pt.waterLevel[2];
        dbga.growthLevel_04 = pt.waterLevel[3];
        dbga.growthLevel_05 = pt.waterLevel[4];

        dbga._OnSaveData_Garden();
    }
}
