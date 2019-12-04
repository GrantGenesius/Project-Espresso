using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameGuessManager : MonoBehaviour
{
    public string[] name;
    public string[] correctNames;
    public string[] mispelledNames;
    public TextMeshProUGUI[] wrongNameDisplay;
    public TMP_InputField nameInput;
    private int randNumber;

    public TextMeshProUGUI logText;

    void Start()
    {
        RandomName();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            logText.text = "Guess the correct name!";
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
        logText.text = "Guess the correct name!";
        nameInput.text = "";
        randNumber = Random.Range(0, name.Length / 4);
        for (int i = 0; i < 3; i++)
        {
            wrongNameDisplay[i].text = "" + name[(randNumber * 4) + i];
        }
    }
}
