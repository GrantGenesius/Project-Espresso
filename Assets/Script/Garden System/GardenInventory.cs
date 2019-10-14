using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GardenInventory : MonoBehaviour
{
    public BrewIngridientList bil;
    public AllImageDatabase aid;
    public GameObject[] imageIngridient;

    
    // Start is called before the first frame update
    void Start()
    {
        aid = FindObjectOfType<AllImageDatabase>();
        bil = FindObjectOfType<BrewIngridientList>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
