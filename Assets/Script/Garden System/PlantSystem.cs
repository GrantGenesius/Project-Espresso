using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSystem : MonoBehaviour
{
    public Sprite[] forms;
    public int amountWatering;
    public int[] levelOfWatering;
    public Collider2D currentTanahPlantSystem;
    public Color normalColor;
    public Color wateredColor;
    
    // Start is called before the first frame update
    void Start()
    {
        normalColor = gameObject.GetComponent<SpriteRenderer>().color;
       
    }

    // Update is called once per frame
    void Update()
    {
        if(amountWatering >= levelOfWatering[0] && amountWatering < levelOfWatering[1])
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = forms[0];
        }

        if (amountWatering >= levelOfWatering[1] && amountWatering < levelOfWatering[2])
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = forms[1];
        }

        

         if (amountWatering >= levelOfWatering[2])
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = forms[2];
        }

        

    }
}
