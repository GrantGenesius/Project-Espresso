using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlantSystem : MonoBehaviour
{
    public Sprite[] forms;
    public int amountWatering;
    public int[] levelOfWatering;
    public Collider2D currentTanahPlantSystem;
    public Color normalColor;
    public Color wateredColor;

    public BoxCollider2D collider3rdForm;

    public TextMeshPro coolDownDisplay;
    public GameObject iNeedWaterSign;
    int idx;

    public PlantTimer pt;

    void Start()
    {
        normalColor = gameObject.GetComponent<SpriteRenderer>().color;
        pt = FindObjectOfType<PlantTimer>();
        idx = currentTanahPlantSystem.GetComponent<GroundController>().idxGround;
       
    }

    void Update()
    {
        TimeDisplay(idx);
        ActivateDisplay();
        WateringStatus();
    }

    public void OnMouseDown()
    {
        HarvestTree();
        Debug.Log("Terbakar");
    }

    public void WateringStatus()
    {
        if (amountWatering >= levelOfWatering[0] && amountWatering < levelOfWatering[1] && !pt.timerHasStarted[idx])
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = forms[0];
        }

        if (amountWatering >= levelOfWatering[1] && amountWatering < levelOfWatering[2] && !pt.timerHasStarted[idx])
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = forms[1];
        }



        if (amountWatering >= levelOfWatering[2] && !pt.timerHasStarted[idx])
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = forms[2];
            collider3rdForm.enabled = true;
            iNeedWaterSign.SetActive(false);
        }
    }
    public void ActivateDisplay()
    {
        if (pt.hour[idx] <= 0 && pt.minutes[idx] <= 0 && pt.seconds[idx] <= 0)
        {
            coolDownDisplay.gameObject.SetActive(false);
            iNeedWaterSign.SetActive(true);
        }
        else
        {
            coolDownDisplay.gameObject.SetActive(true);
            iNeedWaterSign.SetActive(false);
        }

        
    }
    public void TimeDisplay(int i)
    {

      
        if (pt.hour[i] < 10)
        {
            coolDownDisplay.text = "0" + (int)pt.hour[i] + " : "; 
        }
        else
        {
            coolDownDisplay.text = (int)pt.hour[i] + " : ";
        }


        
        if(pt.minutes[i] < 10)
        {
            coolDownDisplay.text += "0"+(int)pt.minutes[i] + " : ";
        }
        else
        {
            coolDownDisplay.text += (int)pt.minutes[i] + " : ";
        }

        
        if(pt.seconds[i] < 10)
        {
            coolDownDisplay.text += "0" + (int)pt.seconds[i];
        }
        else{
            coolDownDisplay.text += (int)pt.seconds[i];
        }

    }

    public void HarvestTree()
    {
        if(amountWatering >= levelOfWatering[2])
        {
            //masukin instantiate disini
            Destroy(gameObject);
        }
        
    }
}
