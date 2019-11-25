using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BubbleBehaviour : MonoBehaviour
{
    DB_Ingredients dbi;
    //DB_AllSprites dbas;
    public SpriteRenderer spawnedIngredientImage;
    public Sprite[] ingredientSprites;
    public Rigidbody2D rb;
    public int ingredientID;
    public int ingredientType;
    public TextMeshPro text;

    void Start()
    {
        ingredientSprites = DB_AllSprites.instance.allIngridient;
        
        
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = Random.insideUnitSphere * 10;
        rb.AddForce(transform.up * 5);
        StartCoroutine(DestroyIn(5));
        SetIngredientType();
    }

    public IEnumerator DestroyIn(float seconds) {
        yield return new WaitForSeconds(seconds);
        Destroy(this.gameObject);
    }

    public void SetIngredientType(){
        dbi = FindObjectOfType<DB_Ingredients>();
        ingredientType = Random.Range(0,100);
        if(ingredientType >= 0 && ingredientType < 90)
        {
            ingredientID = Random.Range(0,6);
            dbi.BrewIngredientsList[ingredientID]++;
        }
        else if (ingredientType >= 90 && ingredientType < 99)
        {
            ingredientID = Random.Range(7, 31);
            dbi.BrewIngredientsList[ingredientID]++;
        }
        else if (ingredientType == 100)
        {
            ingredientID = Random.Range(32, 35);
            dbi.BrewIngredientsList[ingredientID]++;
        }
        text.text = "" + ingredientID;
        //set image here
        spawnedIngredientImage.sprite = ingredientSprites[ingredientID];

    }

}
