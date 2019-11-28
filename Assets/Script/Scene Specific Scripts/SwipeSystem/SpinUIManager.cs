using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinUIManager : MonoBehaviour
{
    public GameObject BG01;
    public GameObject BG02;
    public GameObject viewObject;
    public GameObject spinObject;

    //360 building view
    public void ActivateBG01() 
    {
        viewObject.SetActive(true);
        spinObject.SetActive(false);
        BG02.SetActive(false);
        BG01.SetActive(true);
    }

    //spin/swipe logo
    public void ActivateBG02()
    {
        spinObject.SetActive(true);
        viewObject.SetActive(false);
        BG01.SetActive(false);
        BG02.SetActive(true);
    }
}
