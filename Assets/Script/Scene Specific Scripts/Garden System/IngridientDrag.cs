using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IngridientDrag : MonoBehaviour
{

    public DB_Garden dbga;

    public Vector3 initiateSize;
    private float deltaX, deltaY;
    private Vector2 mousePosition;
    private Vector2 initialPosition;

    public Collider2D currentTanahDrag;

    //Ukuran No
    public Vector3 startSize;
    public Vector3 clickedSize;

    //Target dimana objek harus diletakkan
    public GameObject targetObject;

    //Apakah objek sudah di posisi target
    public bool onTarget;

    //Apakah objek sudah terkunci di posisi target
    public bool locked;

    public int ingridientId;
    public GameObject plantResult;
    public Transform landingPosition;

    public TextMeshPro quantity;


    public BrewIngridientList bil;
    // Use this for initialization
    void Start()
    {
        bil = FindObjectOfType<BrewIngridientList>();
        initiateSize = GetComponent<SpriteRenderer>().transform.localScale;
        dbga = FindObjectOfType<DB_Garden>();
        locked = false;
        onTarget = false;
       
        quantity.text = "X" + bil.valueIngridient[ingridientId];

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (locked == false && bil.valueIngridient[ingridientId] > 0)
        {
            deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;

            deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;

            //transform.localScale = clickedSize;
            GameObject j = Instantiate(gameObject, gameObject.transform.position, gameObject.transform.rotation);
            j.transform.localScale = new Vector3(0.099f,0.099f,0.099f); 
           
           

        }
    }

    private void OnMouseDrag()
    {
        if (locked == false && bil.valueIngridient[ingridientId] > 0)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
            
        }
    }


    private void OnMouseUp()
	{
		if (!onTarget ) {
            if(bil.valueIngridient[ingridientId] > 0)
            {
                Destroy(gameObject);
            }
            
			//transform.position = new Vector2 (initialPosition.x, initialPosition.y);
			
		} else {
            
            GameObject g = Instantiate(plantResult,landingPosition.transform.position, Quaternion.identity) ;
            g.GetComponent<PlantSystem>().currentTanahPlantSystem = currentTanahDrag;
            //g.GetComponent<PlantSystem>().typeOfPlant = ingridientId-1;
            
            //print("kepanggil");
            
            if (bil.valueIngridient[ingridientId] > 0)
            {
                Destroy(gameObject);
            }

            bil.valueIngridient[ingridientId]--;
            quantity.text = "X" + bil.valueIngridient[ingridientId];
            //locked = true;
        }
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Tanah") {
			onTarget = true;
            landingPosition = other.transform;
            currentTanahDrag = other;

        
            

        }
	}

    private void OnTriggerStay2D(Collider2D other)
    {
          if(other.tag == "Tanaman")
        {
            onTarget = false;
            currentTanahDrag = null;
        }
    }


    void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Tanah")
        {
			onTarget = false;
            currentTanahDrag = null;
        }
	}



}
