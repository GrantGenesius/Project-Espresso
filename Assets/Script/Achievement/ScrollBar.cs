using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBar : MonoBehaviour
{
    public Slider slideBar;
    public GameObject highestFrame;
    public GameObject lowestFrame;
    public Rigidbody2D allFrame;
    // Start is called before the first frame update
    void Start()
    {   slideBar.minValue = highestFrame.transform.localPosition.y;
        slideBar.value = highestFrame.transform.localPosition.y;
        slideBar.maxValue = highestFrame.transform.localPosition.y + lowestFrame.transform.localPosition.y; ;
        //slideBar.maxValue = (batasAtas.transform.position.y - batasBawah.transform.position.y);
        allFrame = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(transform.position.x, slideBar.value, transform.position.z);    
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Batas Bawah")
        {
            allFrame.velocity = new Vector2(0, 100);
        }

        if(collision.tag == "Batas Atas")
        {
            allFrame.velocity = new Vector2(0, -100);
        }

       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Batas Bawah")
        {
            allFrame.velocity = new Vector2(0,0);
        }

        if (collision.tag == "Batas Atas")
        {
            allFrame.velocity = new Vector2(0,0);
        }
    }
}
