using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GroundController : MonoBehaviour
{
    public bool moistStatus;
    public bool hovering;
    public int idxGround;
    public Color tanahColor;
    public PlantTimer pt;
    public TextMeshPro coolDownDisplay;
    public GameObject needWater;

    void Start()
    {
        tanahColor = gameObject.GetComponent<SpriteRenderer>().color;
        pt = FindObjectOfType<PlantTimer>();
    }

    void Update()
    {
        if (pt.waterLevel[idxGround] < 30 && pt.plantIDHolder[idxGround] != -1)
        {

            if (pt.timerHasStarted[idxGround] == false)
            {
                moistStatus = false;
                needWater.SetActive(true);
                coolDownDisplay.gameObject.SetActive(false);
            }
            else
            {
                moistStatus = true;
            }
            if (moistStatus)
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(133 / 255f, 133 / 255f, 133 / 255f, 1);
                coolDownDisplay.gameObject.SetActive(true);
                needWater.SetActive(false);
                TimeDisplay(idxGround);
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().color = tanahColor;

            }
        }
        else
        {
            needWater.SetActive(false);
            coolDownDisplay.gameObject.SetActive(false);
        }

        if (hovering)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(178 / 255f, 178 / 255f, 178 / 255f, 1);
        }
        if(!hovering && !moistStatus)
        {
            gameObject.GetComponent<SpriteRenderer>().color = tanahColor;
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


        if (pt.minutes[i] < 10)
        {
            coolDownDisplay.text += "0" + (int)pt.minutes[i] + " : ";
        }
        else
        {
            coolDownDisplay.text += (int)pt.minutes[i] + " : ";
        }


        if (pt.seconds[i] < 10)
        {
            coolDownDisplay.text += "0" + (int)pt.seconds[i];
        }
        else
        {
            coolDownDisplay.text += (int)pt.seconds[i];
        }

    }
}
