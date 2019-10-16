﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GeoLocation : MonoBehaviour
{

    public static GeoLocation Instance { set; get; }
    //current status and location
    float latitude;
    float longitude;
    string status;

    public float distanceRadius;
    public TextMeshPro text;

    //lists of location and name
    public Vector2[] latitudelongitude;
    public string[] locationName;
    [Range(0, 2)]
    public int[] locationType;


    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(StartLocationServices());
    }

    private IEnumerator StartLocationServices()
    {
        Input.location.Start();
        if (!Input.location.isEnabledByUser)
        {
            // fungsi ini sebagai counter measure jika user nggak enable
            //GPS
            Debug.Log("GPS is not enabled by user");
            status = "GPS is not enabled by user";
            yield break;
        }

        Input.location.Start();
        // memberi waktu menunggu 20 detik untuk mendapatkan akses GPS
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing
                && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }
        // kalo lewat 20 detik ya berarti gagal koneksi
        if (maxWait <= 0)
        {
            Debug.Log("Timed out");
            status = "Timed Out";
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determine device location");
            status = "Unable to determine device location";
            yield break;
        }

        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;

        yield break;
    }

    void Update()
    {
        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;
        CheckLocation();
    }

    void CheckLocation() {
        bool onSite = false;
        for (int i = 0; i < latitudelongitude.Length; i++ )
        {
            if (latitude > latitudelongitude[i].x - distanceRadius &&
                latitude < latitudelongitude[i].x + distanceRadius &&
                longitude > latitudelongitude[i].y - distanceRadius &&
                longitude < latitudelongitude[i].y + distanceRadius)
            {
                onSite = true;
                //text.text = "You're at" + locationName[i] + ".\nSpin Available";
            }
        }
        if(onSite == false){
            //replace text with a manager object for that scene because this object has singletonian value and therefore shouldnt be 
            //referencing any object directly
            //should this object even be singletonian?

            //text.text = "You're currently not near any Starbucks, please turn on location on your phone and go near a Starbucks";
        }
    }
}