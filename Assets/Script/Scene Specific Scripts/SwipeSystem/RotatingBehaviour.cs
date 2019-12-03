using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBehaviour : MonoBehaviour
{
    Vector3 cursorPrevPos = Vector3.zero;
    Vector3 cursorCurrPos = Vector3.zero;
    public int spinPowerMultiplier;
    public float spinPower = 0;
    public bool spinning = false;
    public float slowRate;
    public bool spinCDAvailable = false;
    public int currDirection = 1;

    public SwipeInput swipeControls;
    public Transform spinObject;
    private Vector3 desiredPosition;

    public ObjectSpawner os;
    public TimeCounter tc;
    public GeoLocation gl;
    public GameObject particle1;

    public bool trueCooldown;
    public bool trueLocation;
    //public Animator anm;

    void Start()
    {
        transform.Rotate(0, 1, 0);
        StartCoroutine(LocationSearch());
        //anm = GetComponent<Animator>();
    }

    void Update()
    {
        if (!spinCDAvailable)
            CheckSpinAvailability();

        SpinInput();
        ConstantRotation();
        ManualRotationInput();
    }

    void SpinInput() {
        if (spinCDAvailable)
        {
            //spins on either direction
            if (swipeControls.SwipeLeft)
            {
                desiredPosition += Vector3.left;
                os.OnSpin();
                spinPower = spinPowerMultiplier;
                currDirection = 1;
                spinCDAvailable = false;
                tc.StartTimer();
            }
            if (swipeControls.SwipeRight)
            {
                desiredPosition += Vector3.right;
                os.OnSpin();
                spinPower = -spinPowerMultiplier;
                currDirection = -1;
                spinCDAvailable = false;
                tc.StartTimer();
            }
            if (swipeControls.Tap)
            {
            }
        }
    }

    void ConstantRotation() {
        //change with rotation
        //spinObject.transform.position = Vector3.MoveTowards(spinObject.transform.position, desiredPosition, 3f*Time.deltaTime);
        //add an if statement here to enable this spin function
        transform.Rotate(0, spinPower, 0);

        //slowly resets spinPower to 0
        if (spinPower > 0)
        {
            spinPower -= slowRate;
        }
        else if (spinPower < 0)
        {
            spinPower += slowRate;
        }
        else if (spinPower == 0)
        {
            spinning = false;
        }

        if (spinPower >= -0.5 && spinPower <= 0.5)
        {
            spinPower = 0;
            spinning = false;
        }

    }

    void ManualRotationInput() {
        //mouse drag object rotation
        if (Input.GetMouseButton(0))
        {
            //anm.SetBool("Shrink", true);
            cursorCurrPos = Input.mousePosition - cursorPrevPos;
            transform.Rotate(transform.up, -Vector3.Dot(cursorCurrPos, Camera.main.transform.right), Space.World);

        }
        else if (spinPower == 0)
        {
            //anm.SetBool("Shrink", false);
            //constant slow rotation
            if (spinCDAvailable == true)
            {
                transform.Rotate(0, currDirection, 0);
            }
        }
        cursorPrevPos = Input.mousePosition;
    }

    void CheckSpinAvailability() {
        if (trueCooldown || trueLocation)
            spinCDAvailable = true;
        
        if (gl.onSite)
        {
            //not on site
            //spinCDAvailable = false;

        }
        else if (gl.locationActive)
        {
            //location is not on
        }
    }

    public IEnumerator LocationSearch() {
        CheckSpinAvailability();
        yield return new WaitForSeconds(5f);
    }

    void OnMouseUp() {
        transform.Rotate(0, 1 * spinPower, 0);
        spinPower -= 1;
    }
}
