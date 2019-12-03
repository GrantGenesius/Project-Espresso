using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameGuessManager : MonoBehaviour
{
    public string[] name;
    public Text[] wrongName;
    public InputField nameInput;
    private int randNumber;

    public Text logText;

    // Start is called before the first frame update
    void Start()
    {
        RandomName();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            RandomName();
        }
    }

    public void SubmitName()
    {
        if (nameInput.text == name[(randNumber * 4) + 3])
        {
            logText.text = "NICE GUESS!";
        }
        else
        {
            logText.text = "WRONG GUESS!";
        }
    }

    public void RandomName()
    {
        logText.text = "Guess The Name";
        nameInput.text = "";
        randNumber = Random.Range(0, name.Length / 4);
        for (int i = 0; i < 3; i++)
        {
            wrongName[i].text = "" + name[(randNumber * 4) + i];
        }
    }
}
