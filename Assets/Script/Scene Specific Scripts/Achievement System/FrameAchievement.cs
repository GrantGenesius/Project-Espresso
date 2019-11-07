using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FrameAchievement : MonoBehaviour
{

    // Start is called before the first frame update
    public int achievementIndex; // ID of Achievement
    public int recipesIndex; // ID of Reward
    public DB_AllSprites dba;
    public DB_Records dbr;
    public AchievementRecipes_Connector arc;

    public string achievementName; 
    public string achievementDescription;

    public TextMeshProUGUI nameHolder;
    public TextMeshProUGUI descHolder;
    public Button claimsReward;
    //public Image recipes;
   
    public Image achievementIcon;
    public AchievementUnlock au;
    public AllRecipes ar;

    void Start()
    {
        au = FindObjectOfType<AchievementUnlock>();
        ar = FindObjectOfType<AllRecipes>();
        dba = FindObjectOfType<DB_AllSprites>();
        dbr = FindObjectOfType<DB_Records>();
        arc = FindObjectOfType<AchievementRecipes_Connector>();
        //=============================================== Ubah, masukin Database
        nameHolder.text = achievementName;
        descHolder.text = achievementDescription;
        claimsReward.interactable = false;
        if (au.allAchievement[achievementIndex] && !au.alreadyClaimed[achievementIndex])
        {
            claimsReward.interactable = true;
        }
        achievementIcon.sprite = dba.allDrink[recipesIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void claimReward()
    {
        claimsReward.interactable = false;
        au.alreadyClaimed[achievementIndex] = true;
        //ar.alreadyClaimed[recipesIndex] = true;
        arc.recipesUnlocked[recipesIndex] = true;
        arc.SavingTemporary();

    }
}
