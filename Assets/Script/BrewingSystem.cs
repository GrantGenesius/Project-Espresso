using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrewingSystem : MonoBehaviour
{
    public BrewIngridientList bil;

    //reference objects
    public Image[] itemSlot;
    public Image[] inputSlot;
    public Sprite[] allItemImage;

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
    string comparingSlot;

    //public string[] drinkCodes;
    //public string[] drinkNames;


    public int categoryNumber;
    void Start()
    {
        bil = FindObjectOfType<BrewIngridientList>();
        _OnChooseCategory(0);
       
    }
    

    public void _OnChooseCategory(int x)
    {
        categoryNumber = x;
        CheckCategory(categoryNumber);
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].sprite = allItemImage[theSlot[i]];
            itemSlot[i].gameObject.SetActive(true);
            if (theSlot[i] == 0)
            {
                itemSlot[i].gameObject.SetActive(false); 
            }
        }

        for (int i=0; i<itemSlot.Length; i++)
        {
            itemSlot[i].sprite = allItemImage[theSlot[i]];
        }
    }

    public void _OnInputItem(int indexButton)
    {
        //

        //
        CheckCategory(categoryNumber);
        if (numberOfSlot < 8 && bil.valueIngridient[theSlot[indexButton]] > 0)// bil disini bakal diubah jadi Ingridient Database
        {
            if (bil.isExperimenting == false)// bil disini bakal diubah jadi Ingridient Database
            {
                
                bil.valueIngridient[theSlot[indexButton]]--;// bil disini bakal diubah jadi Ingridient Database
                bil.valueChange[theSlot[indexButton]]++;// bil disini bakal diubah jadi Ingridient Database
            }
            inputSlot[numberOfSlot].gameObject.SetActive(true);
            inputSlot[numberOfSlot].sprite = allItemImage[theSlot[indexButton]]; // bil disini bakal diubah jadi Ingridient Database
            inputIngridientSlot[numberOfSlot] += (char)(64+(int)theSlot[indexButton]);
            print(inputIngridientSlot[numberOfSlot]);
            
            numberOfSlot++;
            
        }
    }
    
    public void _OnResetDrink()
    {
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
            inputSlot[i].sprite = allItemImage[0];// bil disini bakal diubah jadi Ingridient Database
            inputSlot[i].gameObject.SetActive(false);// bil disini bakal diubah jadi Ingridient Database
        }
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
    }

    public void _OnBrewDrink() {
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
                //drink ID exists
                result = bil.nameDrink[i];// bil disini bakal diubah jadi Ingridient Database
                print("eyyy brah you got " + result);
                break;
            }
        }
        //drink not found
        if(result == "")
        {
            print("Sorry brah you dont get anything");
        }

        for(int i=0; i < bil.valueChange.Length; i++)// bil disini bakal diubah jadi Ingridient Database
        {
            bil.valueChange[i] = 0;// bil disini bakal diubah jadi Ingridient Database
        }
    }
}
