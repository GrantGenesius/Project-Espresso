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

    public PlantTimer pt;
    public Garden_Connector gc;

    void Start()
    {
        initialPosition = transform.position;
        pt = FindObjectOfType<PlantTimer>();
        gc = FindObjectOfType<Garden_Connector>();
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
            if (!colTanahTemp.gameObject.GetComponent<GroundController>().moistStatus)
            {
                pt.waterLevel[colTemp.gameObject.GetComponent<PlantSystem>().idx] += valueWatering;
                colTanahTemp.gameObject.GetComponent<GroundController>().moistStatus = true;
                //pt.allGround[colTanahTemp.gameObject.GetComponent<GroundController>().idxGround] = colTanahTemp.gameObject;
                pt.moisturizesCooldown[colTanahTemp.gameObject.GetComponent<GroundController>().idxGround] = 86400 ;
                pt.timerHasStarted[colTanahTemp.gameObject.GetComponent<GroundController>().idxGround] = true;
            }
            gameObject.transform.position = initialPosition;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Tanaman")
        {
            onTarget = true;
            colTemp = collision;
           // colTemp.GetComponent<PlantSystem>().currentTanahPlantSystem.GetComponent<SpriteRenderer>().color = Color.blue;
        }

        if (collision.tag == "Tanah")
        {
            colTanahTemp = collision;
            colTanahTemp.gameObject.GetComponent<GroundController>().hovering = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Tanaman")
        {
            //colTemp.GetComponent<PlantSystem>().currentTanahPlantSystem.GetComponent<SpriteRenderer>().color =
            //    colTemp.GetComponent<PlantSystem>().normalColor;
            onTarget = false;
            colTemp = null;
            
        }

        if (collision.tag == "Tanah")
        {
            colTanahTemp.gameObject.GetComponent<GroundController>().hovering = false;
            colTanahTemp = null;
        }

      
    }
}
