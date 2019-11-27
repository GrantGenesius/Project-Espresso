using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinUIManager : MonoBehaviour
{
    public GameObject BG01;
    public GameObject BG02;

    public void ActivateBG01() 
    {
        BG02.SetActive(false);
        BG01.SetActive(true);
    }

    public void ActivateBG02()
    {
        BG01.SetActive(false);
        BG02.SetActive(true);
    }
}
