﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AchievementUnlock : MonoBehaviour
{

    public DB_Records dbr;
    public AchievementRecipes_Connector arc;
    public bool[] allAchievement;
    public bool[] alreadyClaimed;

    private void Start()
    {
        dbr = FindObjectOfType<DB_Records>();
        arc = FindObjectOfType<AchievementRecipes_Connector>();
    }

  
  
}
