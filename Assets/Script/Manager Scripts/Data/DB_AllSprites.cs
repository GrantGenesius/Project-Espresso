using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB_AllSprites : MonoBehaviour
{
    public Sprite[] allIngridient;
    public Sprite[] allDrink;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public DB_AllSprites instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
