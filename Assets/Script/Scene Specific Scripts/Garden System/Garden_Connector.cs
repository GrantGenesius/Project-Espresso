    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garden_Connector : MonoBehaviour
{
    // Start is called before the first frame update

    public PlantTimer pt;
    public DB_General  dbg;
    public GroundController gc;
    public NavigationSystem ns;
    public DB_Garden dbGarden;
    public GameObject[] groundHolder;
    public GameObject[] plantHolder;
    public int[] moistCoolDownHolder;
    public int[] growthPlantLevelHolder;
    void Start()
    {
        pt.ConvertStringtoPlantID();
        loadPlant();
        ReduceMoistCooldown();
    }

    public void Awake()
    {
        ns = FindObjectOfType<NavigationSystem>();
        pt = FindObjectOfType<PlantTimer>();
        pt.allGround = groundHolder;
        dbg = FindObjectOfType<DB_General>();
        dbGarden = FindObjectOfType<DB_Garden>();
        
        //ns.LoadGarden();
        //pt.waterLevel = growthPlantLevelHolder;
    }
    public void ReduceMoistCooldown()
    {
        int counter = 0;
        foreach (float x in pt.moisturizesCooldown)
        {
            if (dbg._24HrsPassed == true)
            {
                pt.moisturizesCooldown[counter] = 0;
                pt.waterLevel[counter] += 10;
                pt.timerHasStarted[counter] = false;
                counter++;
            }
            else if (pt.moisturizesCooldown[counter] > 0)
            {
                pt.moisturizesCooldown[counter] -= ((dbg.hourPassed * 3600) + (dbg.minutePassed * 60) + (dbg.secondPassed));
                if (pt.moisturizesCooldown[counter] < ((dbg.hourPassed * 3600) + (dbg.minutePassed * 60) + (dbg.secondPassed)))
                {
                    pt.moisturizesCooldown[counter] = 0;
                    pt.waterLevel[counter] += 10;
                    pt.timerHasStarted[counter] = false;
                }
                counter++;

            }

        }

    }

    public void loadPlant()
    {
        pt.allGround = groundHolder;
        for(int i = 0; i<groundHolder.Length; i++)
        {
            if (pt.plantIDHolder[i] != -1) {

                GameObject g = Instantiate(plantHolder[pt.plantIDHolder[i]], groundHolder[i].transform.position, Quaternion.identity);
                

                g.GetComponent<PlantSystem>().idx = i;
                g.GetComponent<PlantSystem>().currentTanahPlantSystem = groundHolder[i].gameObject.GetComponent<Collider2D>();
                if(pt.moisturizesCooldown[i] > 0)
                {
                    pt.timerHasStarted[i] = true;
                }

            }
            
        }
    }
}
