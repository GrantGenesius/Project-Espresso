using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AllFrame : MonoBehaviour
{
    public GameObject[] categoryIng;
    public GameObject[] frames;
    public FrameExchange[] frameDetails;
    public GameObject theNav;
    public string highlightedCategory;
    public TextMeshProUGUI processingText;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //_OnChooseCategory(highlightedCategory);
    }

    public void _OnChooseCategory(string hlCategory)
    {
        //for(int i=0; i < frames.Length; i++)
        //{
        //    if(frameDetails[i].typeOfString == hlCategory || frameDetails[i].typeOfString ==  "ALL")
        //    {
        //        frames[i].SetActive(true);
        //    }
        //    else
        //    {
        //        frames[i].SetActive(false);
        //    }
        //}
        if(hlCategory == "Coffee")
        {
            categoryIng[0].SetActive(true);
            categoryIng[1].SetActive(false);
            categoryIng[2].SetActive(false);
            categoryIng[3].SetActive(false);
            categoryIng[4].SetActive(false);
            categoryIng[5].SetActive(false);
        }
        else if(hlCategory == "Tea Leaves")
        {
            categoryIng[0].SetActive(false);
            categoryIng[1].SetActive(true);
            categoryIng[2].SetActive(false);
            categoryIng[3].SetActive(false);
            categoryIng[4].SetActive(false);
            categoryIng[5].SetActive(false);
        }
        else if (hlCategory == "Water")
        {
            categoryIng[0].SetActive(false);
            categoryIng[1].SetActive(false);
            categoryIng[2].SetActive(true);
            categoryIng[3].SetActive(false);
            categoryIng[4].SetActive(false);
            categoryIng[5].SetActive(false);
        }
        else if (hlCategory == "Cocoa")
        {
            categoryIng[0].SetActive(false);
            categoryIng[1].SetActive(false);
            categoryIng[2].SetActive(false);
            categoryIng[3].SetActive(true);
            categoryIng[4].SetActive(false);
            categoryIng[5].SetActive(false);
        }
        else if (hlCategory == "Milk")
        {
            categoryIng[0].SetActive(false);
            categoryIng[1].SetActive(false);
            categoryIng[2].SetActive(false);
            categoryIng[3].SetActive(false);
            categoryIng[4].SetActive(true);
            categoryIng[5].SetActive(false);
        }
        else if (hlCategory == "Sugar")
        {
            categoryIng[0].SetActive(false);
            categoryIng[1].SetActive(false);
            categoryIng[2].SetActive(false);
            categoryIng[3].SetActive(false);
            categoryIng[4].SetActive(false);
            categoryIng[5].SetActive(true);
        }
        processingText.text = hlCategory + " Processing";
        
        theNav.SetActive(false);
    }

    public void _OnClickNavigation()
    {
        theNav.SetActive(true);
    }
}
