using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpinUIManager : MonoBehaviour
{
    public GameObject BG01;
    public GameObject BG02;
    public GameObject viewObject;
    public GameObject spinObject;
    public Button objectButton;
    public GameObject timerObject;
    public GameObject addressObject;

    public TextMeshProUGUI addressText;
    public TextMeshProUGUI notificationText;
    public TextMeshProUGUI timerText;

    public GeoLocation GL;

    //to change location button image onClick
    public Sprite refreshImage;
    public Sprite locationImage;
    public Image LocationButtonImage;

    //360 building view
    public void ActivateBG01()
    {
        addressObject.SetActive(true);
        timerObject.SetActive(false);
        viewObject.SetActive(true);
        spinObject.SetActive(false);
        BG02.SetActive(false);
        BG01.SetActive(true);
    }

    //spin/swipe logo
    public void ActivateBG02()
    {
        RefreshLocationImage();
        GL.RefreshLocation();
        addressObject.SetActive(false);
        timerObject.SetActive(true);
        spinObject.SetActive(true);
        viewObject.SetActive(false);
        BG01.SetActive(false);
        BG02.SetActive(true);
    }

    public void RefreshLocationImage() { 
        //call location refresh function from another script here
        LocationButtonImage.sprite = locationImage;

    }

    public void RequestRefreshLocation() {
        //called after location is not valid or location is off
        LocationButtonImage.sprite = refreshImage;
    }

    //public void DisableObjectViewButton() {
    //    objectButton.interactable = false;
    //}

    //public void EnableObjectViewButton()
    //{
    //    objectButton.interactable = false;
    //}
}
