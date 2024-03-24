using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlay : MonoBehaviour
{
  
    public Slider volumeSlider;
    public GameObject ObjMusic;

    //Value from slider, and it converts to volume level
    [SerializeField]
    private float _musicVolume;
    private float MusicVolume
    {
        get
        {
            _musicVolume = PlayerPrefs.GetFloat("volume");
            Debug.Log("Get Volume : " + _musicVolume);
            //if(_musicVolume < )
            //PlayerPrefs.SetFloat("volume", _musicVolume);

            return _musicVolume;
        }

        set
        {
            _musicVolume = value;
            Debug.Log("Set Volume : " + _musicVolume);

            PlayerPrefs.SetFloat("volume", _musicVolume);
            AudioSource.volume = _musicVolume;
            volumeSlider.value = _musicVolume;
        }
    }


    private AudioSource AudioSource;

    // Start is called before the first frame update
    private void Start()
    {
        ObjMusic = GameObject.FindWithTag("BGM");
        AudioSource = ObjMusic.GetComponent<AudioSource>();

        //Set Volume
        MusicVolume = MusicVolume;

       // MusicVolume = PlayerPrefs.GetFloat("volume");
       // MusicVolume = 0.8f;
       // AudioSource.volume = MusicVolume;
       // volumeSlider.value = MusicVolume;
    }

    // Update is called once per frame
    /*
    private void Update()
    {
        //AudioSource.volume = MusicVolume;
       // PlayerPrefs.SetFloat("volume", MusicVolume);
    }
    */

    public void VolumeUpdate(float volume)
    {
        MusicVolume = volume;
        if(MusicVolume <= 0)
        {
            
        }
    }

    public void MusicReset()
    {
        MusicVolume = 1;
        //PlayerPrefs.DeleteKey("volume");
       // AudioSource.volume = 1;
       // volumeSlider.value = 1;
    }
}
