using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoisturizesPlant : MonoBehaviour
{
    public float deltaX, deltaY;
    public Vector2 mousePosition;
    
    public bool onTarget;
    public bool onTanah;
    //penampung object pas diambil di Collider
    public Collider2D colTemp;
    public Collider2D colTanahTemp;
    //letak awal
    public Vector2 initialPosition;
    //jumlah kualitas air yang diberikan
    public int valueWatering;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;

        deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
    }

    private void OnMouseDrag()
    {

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
        if (onTarget)
        {
            colTemp.GetComponent <PlantSystem>().currentTanahPlantSystem.GetComponent<SpriteRenderer>().color = new Color(0,0,0,1);

        }
        

        
    }

    private void OnMouseUp()
    {
        if (!onTarget)
        {
            gameObject.transform.position = initialPosition;
        }
        else
        {
            colTemp.gameObject.GetComponent<PlantSystem>().amountWatering += valueWatering ;
            gameObject.transform.position = initialPosition;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Tanaman")
        {
            onTarget = true;
            colTemp = collision;
            colTemp.GetComponent<PlantSystem>().currentTanahPlantSystem.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
        }

      
        
    }

    

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Tanaman")
        {
            colTemp.GetComponent<PlantSystem>().currentTanahPlantSystem.GetComponent<SpriteRenderer>().color =
                colTemp.GetComponent<PlantSystem>().normalColor;
            onTarget = false;
            colTemp = null;
            
        }

      
    }
}
