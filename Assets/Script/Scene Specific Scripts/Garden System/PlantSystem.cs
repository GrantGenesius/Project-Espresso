using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlantSystem : MonoBehaviour
{
    public DB_Garden dbga;
    public DB_Records dbr;
    public Garden_Connector gc;
    public NavigationSystem ns;

    public Sprite[] forms;
    public int amountWatering;
    public int holderWater;
    public int[] levelOfWatering;
    public Collider2D currentTanahPlantSystem;
    public Color normalColor;
    public Color wateredColor;

    public BoxCollider2D collider3rdForm;

    //public TextMeshPro coolDownDisplay;
    //public GameObject iNeedWaterSign;
    public int typeOfPlant;
    public int idx;

    public PlantTimer pt;

    void Start()
    {
        normalColor = gameObject.GetComponent<SpriteRenderer>().color;
        dbga = FindObjectOfType<DB_Garden>();
        dbr = FindObjectOfType<DB_Records>();
        pt = FindObjectOfType<PlantTimer>();
        gc = FindObjectOfType<Garden_Connector>();
        idx = currentTanahPlantSystem.GetComponent<GroundController>().idxGround;
        ns = FindObjectOfType<NavigationSystem>();
        holderWater = 0;
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + 1.2f, 1);

       pt.plantIDHolder[idx] = typeOfPlant;
    }

    void Update()
    {
        amountWatering = pt.waterLevel[idx];
        
        //IncreaseAmountofWater();
        //TimeDisplay(idx);
       // ActivateDisplay();
        WateringStatus();
    }

    public void OnMouseDown()
    {
        HarvestTree();
        Debug.Log("Terbakar");
    }

    public void WateringStatus()
    {
        if (amountWatering >= levelOfWatering[0] && amountWatering < levelOfWatering[1] )
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = forms[0];
        }

        if (amountWatering >= levelOfWatering[1] && amountWatering < levelOfWatering[2] )
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = forms[1];
        }

        if (amountWatering >= levelOfWatering[2] )
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = forms[2];
            collider3rdForm.enabled = true;
           // iNeedWaterSign.SetActive(false);
        }
    }

    //public void ActivateDisplay()
    //{
    //    if (pt.hour[idx] <= 0 && pt.minutes[idx] <= 0 && pt.seconds[idx] <= 0.5f)
    //    {
    //        coolDownDisplay.gameObject.SetActive(false);
    //        iNeedWaterSign.SetActive(true);
    //    }
    //    else
    //    {
    //        coolDownDisplay.gameObject.SetActive(true);
    //        iNeedWaterSign.SetActive(false);
    //    }
    //}

   

    //public void IncreaseAmountofWater()
    //{
    //    if (!pt.timerHasStarted[idx])
    //    {
    //        pt.waterLevel[idx] += holderWater;
    //        holderWater = 0;
    //    }

    //    if (pt.timerHasStarted[idx])
    //    {
    //        holderWater = 10;
    //    }
    //    //ns.SaveGarden();
    //}

    public void HarvestTree()
    {
        if(amountWatering >= levelOfWatering[2])
        {
            //masukin instantiate disini
            Destroy(gameObject);
            pt.moisturizesCooldown[idx] = 0;
            pt.timerHasStarted[idx] = false;
            //gc.moistCoolDownHolder[idx] = 0;
            gc.growthPlantLevelHolder[idx] = 0;
            currentTanahPlantSystem.GetComponent<GroundController>().moistStatus = false;

            pt.plantIDHolder[idx] = -1;
            pt.waterLevel[idx] = 0;
            ns.SaveGarden();
            dbr.harvestCount++;
            dbr._OnSaveData_Records();
        }
        
    }
}
