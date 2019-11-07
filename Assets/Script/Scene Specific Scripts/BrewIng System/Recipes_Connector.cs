using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recipes_Connector : MonoBehaviour
{
    public bool[] recipesUnlocked;
    public DB_Records dbr;
    public DB_AllSprites dbas;
    public Image[] allImageRecipes;
    public BrewIngridientList bil;
    public GameObject recipes;
    public string savedRecipesString;

    // Start is called before the first frame update
    void Start()
    {
       dbr =  FindObjectOfType<DB_Records>();
       bil = FindObjectOfType<BrewIngridientList>();
       dbas = FindObjectOfType<DB_AllSprites>();
       dbr._OnLoadData_Records();

       
      
    }

    // Update is called once per frame
    void Update()
    {
        
        savedRecipesString = dbr.unlockedDrinks;
        ConvertStringToRecipes();
        ActivateRecipes();
         

        

    }

    private void OnDestroy()
    {
       

    }

    public void SavingTemporary()
    {
        ConvertRecipesToString();
        dbr.unlockedDrinks = savedRecipesString;
        dbr._OnSaveData_Records();
    }

    public void _OnClickRecipes(int idx)
    {
        Debug.Log(bil.nameDrink[idx]);
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

    public void ActivateRecipes()
    {
        for(int i = 0; i<recipesUnlocked.Length; i++)
        {
            if(recipesUnlocked[i] == false)
            {
                allImageRecipes[i].gameObject.GetComponent<Image>().color = Color.black;
            }
            else
            {
                allImageRecipes[i].gameObject.GetComponent<Image>().color = Color.white;
            }
            

        }
    }
    
}
