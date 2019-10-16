using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllRecipes : MonoBehaviour
{

    // All Recipes
    public AllImageDatabase imageDB; // ubah jadi SpritesManager
    public Image[] allRecipes;
    public bool[] alreadyClaimed; // ini harusnya ditaro di Database
    
    // Start is called before the first frame update
    void Start()
    {
        imageDB = FindObjectOfType<AllImageDatabase>();
        for(int i=0; i<allRecipes.Length; i++)
        {
            if (alreadyClaimed[i])// ini harusnya ditaro di Database
            {
                allRecipes[i].sprite = imageDB.allDrink[i];// ubah jadi SpritesManager
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
