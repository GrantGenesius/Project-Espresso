using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Recipes_Connector : MonoBehaviour
{
    public bool[] recipesUnlocked;
    public DB_Records dbr;
    public DB_AllSprites dbas;
    public Image[] allImageRecipes;
    public BrewIngridientList bil;
    public BrewingSystem bs;
    public GameObject recipes;
    public string savedRecipesString;


    // for Frame Recipe Details
    public GameObject recipesDetailsFrame;
    public TextMeshProUGUI drinkNameDetails;
    public Image drinkImageResult;
    public Image[] allIngridientDetails;
    public char[] characterConverter;

    public int currentActiveRecipes;

    // Start is called before the first frame update
    void Start()
    {
       dbr =  FindObjectOfType<DB_Records>();
        bs = FindObjectOfType<BrewingSystem>();
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
        currentActiveRecipes = idx - 1;
        idx = idx - 1;
        if (recipesUnlocked[idx])
        {
           
            Debug.Log(bil.nameDrink[idx]);
            recipesDetailsFrame.SetActive(true);
            drinkNameDetails.text = bil.nameDrink[idx];
            changeImageResult(idx);



            for (int i = 0; i < bil.codeDrink[idx].Length; i++)
            {

                characterConverter[i] = System.Convert.ToChar(bil.codeDrink[idx][i]);
                allIngridientDetails[i].gameObject.SetActive(true);
                allIngridientDetails[i].sprite = dbas.allIngridient[((int)characterConverter[i]) - 65];
                Debug.Log(((int)characterConverter[i]) - 65);
            }

            for (int i = bil.codeDrink[idx].Length; i < allIngridientDetails.Length; i++)
            {
                allIngridientDetails[i].gameObject.SetActive(false);
            }

        }
    }

    public void _OnCloseRecipeDetails()
    {
        recipesDetailsFrame.SetActive(false);
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
    

    public void _OnBrewWithRecipes()
    {
        bool canProceed = true;
        for(int i=0; i < bil.codeDrink[currentActiveRecipes].Length; i++)
        {
            if(bil.valueIngridient[(((int)characterConverter[i]) - 65)] > 0)
            {
                 bil.valueIngridient[(((int)characterConverter[i]) - 65)]--;
                 bil.valueChange[(((int)characterConverter[i]) - 65)]++;
            }
            else
            {
                for (int j = 0; j < bil.valueIngridient.Length; j++)
                {
                    bil.valueIngridient[j] += bil.valueChange[i];
                    bil.valueChange[j] = 0;
                }

                canProceed = false;
                break;
            }
           
        }
        
        if(canProceed)
        {
            bs.comparingSlot = bil.codeDrink[currentActiveRecipes];
            bs._OnBrewDrink();
           _OnCloseRecipeDetails();

        }
        
    }

    public void changeImageResult(int i)
    {
        Vector3 startingPosition = drinkImageResult.rectTransform.position;

        //drink ID exists
      
        drinkImageResult.sprite = dbas.allDrink[i];
        drinkImageResult.SetNativeSize();
        drinkImageResult.rectTransform.sizeDelta = new Vector2(drinkImageResult.rectTransform.sizeDelta.x * (float)0.1, drinkImageResult.rectTransform.sizeDelta.y * (float)0.1);
        drinkImageResult.rectTransform.position = startingPosition;
    }
   
}
