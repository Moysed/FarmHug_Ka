using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlaying : MonoBehaviour
{
    public static SFXPlaying singleton;

    public AudioSource Click;
    public AudioSource Plant;
    public AudioSource Watering;
    public AudioSource Pig;
    public AudioSource Duck;
    public AudioSource Cow;


    void Awake()
    {
        singleton = this;
    }

    void Start()
    {
        Click.Stop();
        Plant.Stop();
        Watering.Stop();
        Pig.Stop();
        Duck.Stop();
        Cow.Stop();
    }
    /*public void PlayClick()
    {
        Click.Play();
    }
    public void PlayPlant()
    {
        Plant.Play();
    }
    public void PlayWatering()
    {
        Watering.Play();
    }
    public void PlayPig()
    {
        Pig.Play();
    }
    public void PlayDuck()
    {
        Duck.Play();
    }
    public void PlayCow()
    {
        Cow.Play();
    }*/
}
