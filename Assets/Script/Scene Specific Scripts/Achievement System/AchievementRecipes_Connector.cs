using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementRecipes_Connector : MonoBehaviour
{
    public bool[] recipesUnlocked;
    public DB_Records dbr;
    public DB_AllSprites dbas;
    public bool[] allAchievement;
    public bool[] alreadyClaimed;

    public BrewIngridientList bil;
    public GameObject recipes;
    public string savedRecipesString;
    public string savedAchievementString;

    public GameObject[] allAchievementFrame;

    // Start is called before the first frame update
    void Start()
    {
       dbr = FindObjectOfType<DB_Records>();
       dbas = FindObjectOfType<DB_AllSprites>();
       dbr._OnLoadData_Records();

       
      
    }

    // Update is called once per frame
    void Update()
    {
        
        savedRecipesString = dbr.unlockedDrinks;
        savedAchievementString = dbr.unlockedAchievements;
        ConvertStringToRecipes();
        ConvertStringToAchivements();
         

        

    }

    private void OnDestroy()
    {
       

    }

    public void SavingRecipes()
    {
        ConvertRecipesToString();
        dbr.unlockedDrinks = savedRecipesString;
        dbr._OnSaveData_Records();
    }

    public void SavingAchievement()
    {
        ConvertAchievementsToString();
        dbr.unlockedAchievements = savedAchievementString;
        dbr._OnSaveData_Records();
    }

 

    public void ConvertStringToRecipes()
    {
        string[] convertedRecipes = savedRecipesString.Split('.');
        for(int i = 0; i < convertedRecipes.Length; i++)
        {
            if (i < recipesUnlocked.Length)
            {
                if (convertedRecipes[i] == "1")
                {
                    recipesUnlocked[i] = true;
                }
                else
                {
                    recipesUnlocked[i] = false;
                }
            }
            
        }
    }

    public void ConvertRecipesToString()
    {
        savedRecipesString = "";
        for(int i = 0; i<recipesUnlocked.Length; i++)
        {
            if(recipesUnlocked[i] == true)
            {
                savedRecipesString += "1.";
            }
            else
            {
                savedRecipesString += "0.";
            }
        }
    }

    public void ConvertStringToAchivements()
    {
        string[] convertedAchievement = savedAchievementString.Split('.');
        for (int i = 0; i < convertedAchievement.Length; i++)
        {
            if (i < allAchievement.Length)
            {
                if (convertedAchievement[i] == "0")
                {
                    allAchievement[i] = false;
                }
                else if(convertedAchievement[i] == "1")
                {
                    allAchievement[i] = true;
                    alreadyClaimed[i] = false;
                }
                else if(convertedAchievement[i] == "2")
                {
                    allAchievement[i] = true;
                    alreadyClaimed[i] = true;
                }
            }

        }
    }

    public void ConvertAchievementsToString()
    {
        savedAchievementString = "";
        for (int i = 0; i < allAchievement.Length; i++)
        {
            if (allAchievement[i] == false)
            {
                savedAchievementString += "0.";
            }
            else if(allAchievement[i] == true && alreadyClaimed[i] == false)
            {
                savedAchievementString += "1.";
            }
            else if(allAchievement[i] == true  && alreadyClaimed[i] == true)
            {
                savedAchievementString += "2.";
            }
            
        }
    }

    public void _OnAllAchievement()
    {
        for(int i = 0; i<allAchievement.Length; i++)
        {
            allAchievementFrame[i].SetActive(true);
        }
    }

    public void _OnClaimableAchievement()
    {
        for (int i = 0; i < allAchievement.Length; i++)
        {
            if(allAchievement[i] && !alreadyClaimed[i])
            {
                allAchievementFrame[i].SetActive(true);
            }
            else
            {
                allAchievementFrame[i].SetActive(false);
            }
            
        }
    }

    public void _OnAchievedAchievement()
    {
        for (int i = 0; i < allAchievement.Length; i++)
        {
            if (allAchievement[i])
            {
                allAchievementFrame[i].SetActive(true);
            }
            else
            {
                allAchievementFrame[i].SetActive(false);
            }
        }
    }



}
