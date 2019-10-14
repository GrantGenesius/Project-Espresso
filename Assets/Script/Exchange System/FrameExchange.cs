using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FrameExchange : MonoBehaviour
{
    public AllImageDatabase imageDB;
    public BrewIngridientList bil;

    //ini cuman buat ngasih tau tipe apa
    public string typeOfString;

    //gambar ingridient yg ditampilkan
    public Image[] ingridientImage;
    // id yg dipake buat manggil image
    public int[] ingridientId;
    public int[] ingridientAmountNeeded;
    public int ingridientResultId;
    public Image resultThing;

    public TextMeshProUGUI []amountRequirmentIngredient;



    public Button exchangeButton;

    public bool[] ingridientCheck;

    
    
    // Start is called before the first frame update
    void Start()
    {
        imageDB = FindObjectOfType<AllImageDatabase>();
        bil = FindObjectOfType<BrewIngridientList>();

        for(int i=0; i<ingridientId.Length; i++)
        {
            if (ingridientId[i] != -1)
            {
                ingridientImage[i].sprite = imageDB.allImage[ingridientId[i]];
            }
            else
            {
                ingridientImage[i].gameObject.SetActive(false);
            }
            
        }

        resultThing.sprite = imageDB.allImage[ingridientResultId];
        
        checkAvailable();
    }

    // Update is called once per frame
    void Update()
    {
        checkAvailable();
    }

   
    public void ExchangeTheIngridient()
    {
       
        for (int i=0; i < 3; i++)
            {
            if(ingridientId[i] != -1)
            {
                bil.valueIngridient[ingridientId[i]] -= ingridientAmountNeeded[i];
            }
                
            }
            bil.valueIngridient[ingridientResultId]++;
            print(bil.nameIngridient[ingridientResultId] + "+1");
           
     
    }

    public void checkAvailable()
    {
        for (int i = 0; i < amountRequirmentIngredient.Length; i++)
        {
            if (ingridientId[i] != -1)
            {
                amountRequirmentIngredient[i].gameObject.SetActive(true);
                amountRequirmentIngredient[i].text = bil.valueIngridient[ingridientId[i]] + "/" + ingridientAmountNeeded[i];
            }
            else
            {
                amountRequirmentIngredient[i].gameObject.SetActive(false);
            }
            
        }
        for (int i = 0; i < ingridientCheck.Length; i++)
        {
            ingridientCheck[i] = false;
            if (ingridientId[i] == -1)
            {
                ingridientCheck[i] = true;
            }
            else if (bil.valueIngridient[ingridientId[i]] >= ingridientAmountNeeded[i])
            {
                ingridientCheck[i] = true;
            }
        }

        if (ingridientCheck[0] && ingridientCheck[1] && ingridientCheck[2])
        {
            exchangeButton.interactable = true;
        }
        else
        {
            exchangeButton.interactable = false;
        }
    }
}
