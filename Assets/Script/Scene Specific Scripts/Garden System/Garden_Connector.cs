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
    public int[] moistCoolDownHolder;
    public int[] growthPlantLevelHolder;
    void Start()
    {
        
        
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
}
