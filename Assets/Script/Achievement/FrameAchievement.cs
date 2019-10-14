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

    public string achievementName; 
    public string achievementDescription;

    public TextMeshProUGUI nameHolder;
    public TextMeshProUGUI descHolder;
    public Button claimsReward;
   
    public Image achievementIcon;
    public AchievementUnlock au;
    public AllRecipes ar;

    void Start()
    {
        au = FindObjectOfType<AchievementUnlock>();
        ar = FindObjectOfType<AllRecipes>();
        //=============================================== Ubah, masukin Database
        nameHolder.text = achievementName;
        descHolder.text = achievementDescription;
        claimsReward.interactable = false;
        if (au.allAchievement[achievementIndex] && !au.alreadyClaimed[achievementIndex])
        {
            claimsReward.interactable = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void claimReward()
    {
        claimsReward.interactable = false;
        au.alreadyClaimed[achievementIndex] = true;
        ar.alreadyClaimed[recipesIndex] = true;

    }
}
