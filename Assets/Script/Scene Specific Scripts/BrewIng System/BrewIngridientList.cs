using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BrewIngridientList : MonoBehaviour
{
    public DB_Ingredients dbi;
    public BrewingSystem bs;
    public TextMeshProUGUI experimentText;

    // ini mungkin bakal diubah jadi Database Ingridient
    public int[] valueIngridient;
    public int[] valueChange;
    public string[] nameIngridient;
    public string[] codeDrink;
    public string[] nameDrink;
    
    public bool isExperimenting;

    void Start()
    {
        dbi = FindObjectOfType<DB_Ingredients>();
        bs = FindObjectOfType<BrewingSystem>();
        valueIngridient = dbi.BrewIngredientsList;

    }

    public void ToogleExperimenting()
    {
        bs._OnResetDrink();
        if (isExperimenting)
        {
            isExperimenting = false;
            experimentText.text = "Experiment" + "\n" + "Mode: Deactivated";
        }
        else
        {
            isExperimenting = true;
            experimentText.text = "Experiment" + "\n" + "Mode: Activated";
        }
    }
}

