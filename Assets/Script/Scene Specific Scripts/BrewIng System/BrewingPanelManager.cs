using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrewingPanelManager : MonoBehaviour
{
    public GameObject allRecipes;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenRecipeBook()
    {
        allRecipes.gameObject.SetActive(true);
    }
    public void ClosedRecipeBook()
    {
        allRecipes.gameObject.SetActive(false);
    }
}
