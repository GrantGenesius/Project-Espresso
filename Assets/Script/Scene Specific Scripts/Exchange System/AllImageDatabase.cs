using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllImageDatabase : MonoBehaviour
{
    // ini diubah jadi SpritesManager
    public Sprite[] allIngridient;
    public Sprite[] allDrink;
    public DB_AllSprites dbas;
    
    // Start is called before the first frame update
    void Start()
    {
        dbas = FindObjectOfType<DB_AllSprites>();
        allIngridient = dbas.allIngridient;
        allDrink = dbas.allDrink;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
