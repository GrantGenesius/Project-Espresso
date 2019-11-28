using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] bgm;
    public AudioSource[] sfx;
    public float lo_vol;
    public float med_vol;
    public float hi_vol;
    public float max_vol;

    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        transform.parent = null;
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
        //sets initial volume
        lo_vol = 0.1f;
        med_vol = 0.4f;
        hi_vol = 0.7f;
        max_vol = 1f;
    }

    //function called everytime a scene is loaded
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
    }


    public void PlaySFX(int sfxIndex, float volume)
    {
        sfx[sfxIndex].volume = volume;
        sfx[sfxIndex].Play();
    }

    public void PlayBGM(int sfxIndex, float volume)
    {
        bgm[sfxIndex].volume = volume;
        bgm[sfxIndex].Play();
    }

    public void StopBGM(int sfxIndex)
    {
        bgm[sfxIndex].Stop();
    }

    public void StopSFX(int sfxIndex)
    {
        sfx[sfxIndex].Stop();
    }

}
