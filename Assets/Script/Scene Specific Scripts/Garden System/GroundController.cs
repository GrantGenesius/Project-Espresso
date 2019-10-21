using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    public bool moistStatus;
    public bool hovering;
    public int idxGround;
    public Color tanahColor;
    public PlantTimer pt;
    

    // Start is called before the first frame update
    void Start()
    {
        tanahColor = gameObject.GetComponent<SpriteRenderer>().color;
        pt = FindObjectOfType<PlantTimer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pt.timerHasStarted[idxGround] == false)
        {
            moistStatus = false;
        }
        if (moistStatus)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = tanahColor;

        }

        if (hovering)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        if(!hovering && !moistStatus)
        {
            gameObject.GetComponent<SpriteRenderer>().color = tanahColor;
        }
    }
}
