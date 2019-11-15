using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BrewingSystem : MonoBehaviour
{
    public BrewIngridientList bil;
    public DB_Records dbr;
    public Recipes_Connector rc;
    //reference objects
    public Image drinkResult;
    
    public Image []categoryImage;
    public Image[] itemSlot;
    public TextMeshProUGUI[] stockItem;
    public TextMeshProUGUI[] NameItem;
    public Scrollbar itemScrollBar;

    public Image[] inputSlot;
    public ScrollRect scrollSetting;
    public int categoryManyPage;

    public DB_AllSprites dbas;
    public Sprite []ingredientSprites;
    public Sprite []drinkSprites;
    public Sprite[] categorySprites;


    //opening Succ ess brewin

    public GameObject successBrewingFrame;
    public Image drinkResultImage;
    public TextMeshProUGUI nameDrink;

    //opening failed brewin

    public GameObject failedBrewingFrame;
    


    public DB_Ingredients dbi;
    // UI slots
    //defines itemID
    public int[] theSlot;
    public int numberOfSlot;
    public int[] coffeeSlot;
    public int[] waterSlot;
    public int[] teaSlot;
    public int[] cocoaSlot;
    public int[] sugarSlot;
    public int[] milkSlot;
    public int[] etcSlot;
    
    

    //brewing vars
    [SerializeField]
    char[] inputIngridientSlot;
    [SerializeField]
    public string comparingSlot;

    //public string[] drinkCodes;
    //public string[] drinkNames;


    public int categoryNumber;
    void Start()
    {
        bil = FindObjectOfType<BrewIngridientList>();
        dbi = FindObjectOfType<DB_Ingredients>();
        dbas = FindObjectOfType<DB_AllSprites>();
        dbr = FindObjectOfType<DB_Records>();
        rc = FindObjectOfType<Recipes_Connector>();

        ingredientSprites = dbas.allIngridient;
        drinkSprites = dbas.allDrink;
        _OnChooseCategory(0);
       
    }
    private void Update()
    {
        ItemStock();
    }

    public void ItemStock()
    {
        for (int i = 0; i < stockItem.Length; i++)
        {
            if (theSlot[i] != -1)
            {
                stockItem[i].text = "x" + bil.valueIngridient[theSlot[i]];
                NameItem[i].text = "" + bil.nameIngridient[theSlot[i]];
            }  
        }
        
    }
    

    public void _OnChooseCategory(int x)
    {
        categoryNumber = x;
        categoryManyPage = 0;
        CheckCategory(categoryNumber);
        for (int i = 0; i < itemSlot.Length; i++)
        {
            
            if (theSlot[i] == -1)
            {
                itemSlot[i].gameObject.SetActive(false); 
            }
            else
            {
                itemSlot[i].sprite = ingredientSprites[theSlot[i]];
                itemSlot[i].gameObject.SetActive(true);
                categoryManyPage++;
            }
            itemScrollBar.value = 0;
            
            
        }
    }

    public void _OnInputItem(int indexButton)
    {
        //

        //
        CheckCategory(categoryNumber);
        print(indexButton);
        if (numberOfSlot < 8 && bil.valueIngridient[theSlot[indexButton]] > 0)// bil disini bakal diubah jadi Ingridient Database
        {
            if (bil.isExperimenting == false)// bil disini bakal diubah jadi Ingridient Database
            {
                
                bil.valueIngridient[theSlot[indexButton]]--;// bil disini bakal diubah jadi Ingridient Database
                bil.valueChange[theSlot[indexButton]]++;// bil disini bakal diubah jadi Ingridient Database
            }
            inputSlot[numberOfSlot].gameObject.SetActive(true);
            inputSlot[numberOfSlot].sprite = ingredientSprites[theSlot[indexButton]]; // bil disini bakal diubah jadi Ingridient Database
            inputIngridientSlot[numberOfSlot] += (char)(65+(int)theSlot[indexButton]);
            print(inputIngridientSlot[numberOfSlot]);
            
            numberOfSlot++;
            
        }
    }
    
    public void _OnResetDrink()
    {
        //Debug.Log("wooo");
        numberOfSlot = 0;
        comparingSlot = "";
       
       for(int i=0; i<bil.valueIngridient.Length; i++)// bil disini bakal diubah jadi Ingridient Database
        {
            bil.valueIngridient[i] += bil.valueChange[i];// bil disini bakal diubah jadi Ingridient Database
            bil.valueChange[i] = 0;// bil disini bakal diubah jadi Ingridient Database
        }
        for(int i=0; i < inputIngridientSlot.Length; i++)
        {
            inputIngridientSlot[i] = '\0';
        }
        
        
      for(int i=0; i < inputSlot.Length; i++)
        {
            inputSlot[i].sprite = null;// bil disini bakal diubah jadi Ingridient Database
            inputSlot[i].gameObject.SetActive(false);// bil disini bakal diubah jadi Ingridient Database
        }
        drinkResult.gameObject.SetActive(false);
    }

    void CheckCategory(int x)
    {
        
        if (x == 0)
        {
            theSlot = coffeeSlot;
           
            
        }
        else if (x == 1)
        {
            theSlot = teaSlot;
        }
        else if (x == 2)
        {
            theSlot = waterSlot;
        }
        else if (x == 3)
        {
            theSlot = milkSlot;
        }
        else if (x == 4)
        {
            theSlot = cocoaSlot;
        }
        else if (x == 5)
        {
            theSlot = sugarSlot;
        }
        else if (x == 6)
        {
            theSlot = etcSlot;
        }

        for(int i=0; i < categoryImage.Length; i++)
        {
            if(i == x)
            {
                categoryImage[i].sprite = categorySprites[0];
            }
            else
            {
                categoryImage[i].sprite = categorySprites[1];
            }
        }
    }

  

    public void _OnBrewDrink() {
        Debug.Log("OnBrewDrink");
       
        //ingredient code sorting process
        Array.Sort(inputIngridientSlot);
        //reverses the array content to prevent empty content from starting the sort result
        for (int i = inputIngridientSlot.Length - numberOfSlot; i < inputIngridientSlot.Length; i++)
        {
            comparingSlot += inputIngridientSlot[i];
        }
        //print(comparingSlot);

        //searches the drink ID 
        string result = "";
        for(int i=0; i< bil.codeDrink.Length; i++)// bil disini bakal diubah jadi Ingridient Database
        {
            if(comparingSlot == bil.codeDrink[i])// bil disini bakal diubah jadi Ingridient Database
            {
                Vector3 startingPosition = drinkResult.rectTransform.position;
                    
                //drink ID exists
                result = bil.nameDrink[i];
                drinkResult.sprite = drinkSprites[i];
                drinkResult.SetNativeSize();
                drinkResult.rectTransform.sizeDelta = new Vector2(drinkResult.rectTransform.sizeDelta.x * (float)0.12, drinkResult.rectTransform.sizeDelta.y *(float)0.12);
                drinkResult.rectTransform.position = startingPosition;

                Debug.Log("eyyy brah you got " + result);
                drinkResult.gameObject.SetActive(true);
                rc.recipesUnlocked[i] = true;

                rc.SavingTemporary();
                OpenBrewingSuccessPanel(i);
                dbr.couponsMade++;
                break;
            }
        }
        //drink not found
        if(result == "")
        {
            Debug.Log("Sorry brah you dont get anything");
            drinkResult.sprite = null;
            drinkResult.gameObject.SetActive(false);
            failedBrewingFrame.SetActive(true);
        }
         for (int i = 0; i < inputIngridientSlot.Length; i++)
        {
            inputIngridientSlot[i] = '\0';
        }
        numberOfSlot = 0;
        comparingSlot = "";
        for(int i=0; i < bil.valueChange.Length; i++)// bil disini bakal diubah jadi Ingridient Database
        {
            bil.valueChange[i] = 0;// bil disini bakal diubah jadi Ingridient Database
        }
        for (int i = 0; i < inputSlot.Length; i++)
        {
            inputSlot[i].sprite = null;// bil disini bakal diubah jadi Ingridient Database
            inputSlot[i].gameObject.SetActive(false);// bil disini bakal diubah jadi Ingridient Database
        }

    }

   public void OpenBrewingSuccessPanel(int indexDrink)
        
    {   
        successBrewingFrame.SetActive(true);
        Vector3 startingPosition = drinkResultImage.rectTransform.position;
        drinkResultImage.sprite = dbas.allDrink[indexDrink];   
        drinkResultImage.SetNativeSize();
        drinkResultImage.rectTransform.sizeDelta = new Vector2(drinkResultImage.rectTransform.sizeDelta.x * (float)0.3, drinkResultImage.rectTransform.sizeDelta.y * (float)0.3);
        drinkResultImage.rectTransform.position = startingPosition;
        nameDrink.text = bil.nameDrink[indexDrink];
    }

    public void _OnCloseBrewingSuccessPanel()
    {
        successBrewingFrame.SetActive(false);
    }

    public void _OnCloseFailedSuccessPanel()
    {
        failedBrewingFrame.SetActive(false);
    }
}
