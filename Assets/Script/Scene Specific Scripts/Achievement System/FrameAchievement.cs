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
    public BrewIngridientList bil;
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


    public GameObject unlockedRecipes;
    public Image imageResult;
    public TextMeshProUGUI nameResult;

    void Start()
    {
        au = FindObjectOfType<AchievementUnlock>();
        ar = FindObjectOfType<AllRecipes>();
        dba = FindObjectOfType<DB_AllSprites>();
        dbr = FindObjectOfType<DB_Records>();
        arc = FindObjectOfType<AchievementRecipes_Connector>();
        bil = FindObjectOfType<BrewIngridientList>();
        //=============================================== Ubah, masukin Database
        nameHolder.text = achievementName;
        descHolder.text = achievementDescription;
        claimsReward.interactable = false;
      
       
        Vector3 startingPosition = achievementIcon.rectTransform.position;
        achievementIcon.sprite = dba.allDrink[recipesIndex];
        achievementIcon.SetNativeSize();
        achievementIcon.rectTransform.sizeDelta = new Vector2(achievementIcon.rectTransform.sizeDelta.x * (float)0.13, achievementIcon.rectTransform.sizeDelta.y * (float)0.13);
        achievementIcon.rectTransform.position = new Vector3(startingPosition.x + 15, startingPosition.y + 17, startingPosition.z) ;
    }

    // Update is called once per frame
    void Update()
    {
        if (arc.allAchievement[achievementIndex] && !arc.alreadyClaimed[achievementIndex])
        {
            claimsReward.interactable = true;
        }
        else
        {
            claimsReward.interactable = false;
        }
    }

    public void ClaimReward()
    {
        claimsReward.interactable = false;
        arc.alreadyClaimed[achievementIndex] = true;
        //ar.alreadyClaimed[recipesIndex] = true;
        arc.recipesUnlocked[recipesIndex] = true;
        arc.SavingRecipes();
        arc.SavingAchievement();

        Vector3 startingPosition = imageResult.transform.position;
        unlockedRecipes.SetActive(true);
        imageResult.sprite = dba.allDrink[recipesIndex];
        imageResult.SetNativeSize();
        imageResult.rectTransform.sizeDelta = new Vector2(imageResult.rectTransform.sizeDelta.x * (float)0.4, imageResult.rectTransform.sizeDelta.y * (float)0.4);
        imageResult.rectTransform.position = new Vector2(startingPosition.x, startingPosition.y);
        nameResult.text = dba.allDrinkName[recipesIndex];

    }
    public void CloseClaimReward()
    {
        unlockedRecipes.SetActive(false);
    }
}
