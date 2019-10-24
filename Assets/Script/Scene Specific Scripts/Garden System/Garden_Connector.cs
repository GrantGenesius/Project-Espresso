using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garden_Connector : MonoBehaviour
{
    // Start is called before the first frame update

    public PlantTimer pt;
    public GroundController gc;
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
        pt = FindObjectOfType<PlantTimer>();
        pt.allGround = groundHolder;
    }

    public void OnDestroy()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadPlant()
    {
        for(int i = 0; i<groundHolder.Length; i++)
        {
            if (pt.plantIDHolder[i] != '\0') {

                GameObject g = Instantiate(plantHolder[(int)pt.plantIDHolder[i]-48], groundHolder[i].transform.position, Quaternion.identity);

                g.GetComponent<PlantSystem>().idx = i;
              
            }
            
        }
    }
}
