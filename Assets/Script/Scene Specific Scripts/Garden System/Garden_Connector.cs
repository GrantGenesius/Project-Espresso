    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garden_Connector : MonoBehaviour
{
    // Start is called before the first frame update

    public PlantTimer pt;
    public GroundController gc;
    public NavigationSystem ns;
    public DB_Garden dbGarden;
    public GameObject[] groundHolder;
    public GameObject[] plantHolder;
    public int[] moistCoolDownHolder;
    public int[] growthPlantLevelHolder;
    void Start()
    {
        
        loadPlant();
    }

    public void Awake()
    {
        ns = FindObjectOfType<NavigationSystem>();
        pt = FindObjectOfType<PlantTimer>();
        pt.allGround = groundHolder;
        dbGarden = FindObjectOfType<DB_Garden>();
        ns.LoadGarden();
        //pt.waterLevel = growthPlantLevelHolder;
    }
    

    public void loadPlant()
    {
        for(int i = 0; i<groundHolder.Length; i++)
        {
            if (pt.plantIDHolder[i] != '\0') {

                GameObject g = Instantiate(plantHolder[pt.plantIDHolder[i]], groundHolder[i].transform.position, Quaternion.identity);
                

                g.GetComponent<PlantSystem>().idx = i;
                g.GetComponent<PlantSystem>().currentTanahPlantSystem = groundHolder[i].gameObject.GetComponent<Collider2D>();

            }
            
        }
    }
}
