using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    //public static SFXManager singleton;
    
    [Header("---------------- Audio Source ----------------")]
    [SerializeField] AudioSource sfxSource;

    [Header("---------------- Audio Clip ----------------")]
    public AudioClip Watering;
    public AudioClip Click;
    public AudioClip Plant;
    public AudioClip Crow;
    public AudioClip Mandrake;
    public AudioClip Harvest;
    public AudioClip BuyPlant;
    public AudioClip BuyGround;
    public AudioClip Sold;
    public AudioClip NoMoney;

    /* void Awake()
    {
        singleton = this;
    } */
    
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
