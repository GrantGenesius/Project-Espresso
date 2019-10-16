using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrewIngridientList : MonoBehaviour
{
    public DB_Ingredients dbi;

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
        valueIngridient = dbi.BrewIngredientsList;

    }
}

