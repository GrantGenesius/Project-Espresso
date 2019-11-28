﻿﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectViewer : MonoBehaviour
{

    //Can Use Touch
    bool isTouchDevice;

    public bool RotationEnabled;

    //Speed
    float arrowMouseSpeed = 5.0f;

    void OnEnable() {
        RotationEnabled = false;
    }

    void Start()
    {
        //check if touch device
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            isTouchDevice = true;
        }
        else
        {
            isTouchDevice = false;
        }

        //Get local rotation
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;

    }

    void Update()
    {
        CheckRotationEnabled();

        if (isTouchDevice)
        {
            //Rotate Camera with Accelerometer
            cameraRotationAccelerometer();
        }
        else
        {
            if (RotationEnabled == true)
            {
                //Rotate Camera with Keyboard Arrow and Mouse
                moveWithArrowAndMouse();
            }
        }
    }

    private void CheckRotationEnabled()
    {
        if (Input.GetMouseButtonDown(0))
            RotationEnabled = true;
        if (Input.GetMouseButtonUp(0))
            RotationEnabled = false;
    }

    [ContextMenu("ResetRotation")]
    public void ResetObjectRotation()
    {
        rotX = 0;
        rotY = 0;
        //or maybe play a shrink animation here
    }

    #region accelerometer
    /////////////**** Accelerometer Start****////////////////////////////////////////////////////////
    float xValue;
    float xValueMinMax = 5.0f;

    float yValue;
    float yValueMinMax = 5.0f;

    float cameraSpeed = 20.0f;// Greater the lower speed
    Vector3 accelometerSmoothValue;

    void cameraRotationAccelerometer()
    {
        //Set X Min Max
        if (xValue < -xValueMinMax)
            xValue = -xValueMinMax;

        if (xValue > xValueMinMax)
            xValue = xValueMinMax;

        //Set Y Min Max
        if (yValue < -yValueMinMax)
            yValue = -yValueMinMax;

        if (yValue > yValueMinMax)
            yValue = yValueMinMax;

        accelometerSmoothValue = lowpass();

        xValue += accelometerSmoothValue.x;
        yValue += accelometerSmoothValue.y;

        transform.rotation = new Quaternion(yValue, xValue, 0, cameraSpeed);
    }

    //Smooth Accelerometer
    public float AccelerometerUpdateInterval = 1.0f / 100.0f;
    public float LowPassKernelWidthInSeconds = 0.001f;
    public Vector3 lowPassValue = Vector3.zero;
    Vector3 lowpass()
    {
        float LowPassFilterFactor = AccelerometerUpdateInterval / LowPassKernelWidthInSeconds;//tweakable
        lowPassValue = Vector3.Lerp(lowPassValue, Input.acceleration, LowPassFilterFactor);
        return lowPassValue;
    }
    /////////////**** Accelerometer End****////////////////////////////////////////////////////////
    #endregion

    //Move with Keyboard Arrow
    void moveWithArrowAndMouse()
    {
        //Keyboard Arrow
        moveCamera(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), arrowMouseSpeed);

        //Keyboard Mouse
        moveCamera(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), arrowMouseSpeed);
    }


    //Move Parameters
    float mouseX;
    float mouseY;
    Quaternion localRotation;
    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis

    void moveCamera(float horizontal, float verticle, float moveSpeed)
    {
        mouseX = -horizontal;
        mouseY = -verticle;

        rotX = Mathf.Clamp(rotX, -30, 30);

        rotY += mouseX * moveSpeed;
        rotX += mouseY * moveSpeed;

        localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;
    }
}