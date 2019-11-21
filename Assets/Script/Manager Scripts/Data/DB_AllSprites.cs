﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB_AllSprites : MonoBehaviour
{
    public Sprite[] allIngridient;
    public Sprite[] allDrink;
    public string[] allDrinkName;
    public string[] allIngredientName;


    public DB_AllSprites instance;
    private void Awake()
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
