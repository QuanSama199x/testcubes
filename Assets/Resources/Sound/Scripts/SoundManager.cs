using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : Singleton<SoundManager>
{
    
    public AudioMixer Volume;
    void Start()
    {
        /*Check();*/
    }

    // Update is called once per frame
    void Update()
    {

    }
    /*public void Check()
    {
        if (Data.Instance.Sound)
        {
            setVolume(0);
        }
        else
        {
            setVolume(-80);
        }
    }*/
    public void setVolume(float count)
    {

        Volume.SetFloat("volume", count);
    }
}
