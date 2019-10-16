using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationSystem : MonoBehaviour
{
    public Animator anim;
    public BrewIngridientList bil;
    bool navigationActive;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    public void _OnOpenClose()
    {
        if (navigationActive)
        {
            anim.SetBool("Open", false);
            navigationActive = false;
        }
        else
        {
            anim.SetBool("Open", true);
            navigationActive = true;
        }
    }

    public void _OnSceneManagement(string levelName)
    {
        SceneManager.LoadScene(levelName);

    }
    public void _OnExperiment()
    {
        bil.isExperimenting = true;
    }

    public void _OnNotExperiment()
    {
        bil.isExperimenting = false;
    }
}
