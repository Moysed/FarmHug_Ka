using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class VolumeManager : MonoBehaviour
    {
    //public AudioMixer _audio;
    //public AudioClip _audio;

        public GameObject Audio;
        public GameObject noAudio;

        public Slider volumeSlider;
        public GameObject ObjMusic;
        private AudioSource AudioSource;
        //public float sliderValue;
        //public GameObject on;
        //public GameObject off;

        //Value from slider, and it converts to volume level
        [SerializeField]
        private float _musicVolume;
        private float MusicVolume
        {
            get
            {
                _musicVolume = PlayerPrefs.GetFloat("volume");
                Debug.Log("Get Volume : " + _musicVolume);

                if(volumeSlider != null )
                volumeSlider.value = _musicVolume;
                //if(_musicVolume < )
                //PlayerPrefs.SetFloat("volume", _musicVolume);

                return _musicVolume;
            }

            set
            {
                _musicVolume = value;
                Debug.Log("Set Volume : " + _musicVolume);

                PlayerPrefs.SetFloat("volume", _musicVolume);

                if(AudioSource != null )
                AudioSource.volume = _musicVolume;
            
                //volumeSlider.value = _musicVolume;
            }
        }


        void Start()
        {
            ObjMusic = GameObject.FindWithTag("BGM");
            AudioSource = ObjMusic.GetComponent<AudioSource>();

            //Set Volume
            MusicVolume = MusicVolume;
        //Audio.gameObject.SetActive(true);
        //noAudio.gameObject.SetActive(false);

            /*
            //slider.value = PlayerPrefs.GetFloat("save", sliderValue);
            if (PlayerPrefs.HasKey("musicVolume"))
            {
                PlayerPrefs.SetFloat("musicVolume", 1);
            }
            else
            {
                Load();
            }*/
        }

        /*public void ChangeSlider(float value)
        {
            sliderValue = value;
            PlayerPrefs.SetFloat("save", sliderValue);
        }*/

        public void SetVolume()
        {
            // AudioListener.volume = slider.value;
            MusicVolume = volumeSlider.value;
        }

        public void Load()
        {
            //slider.value = PlayerPrefs.GetFloat("musicVolume");
            //Save();
        }

        public void Save()
        {
           // PlayerPrefs.SetFloat("musicVolume", slider.value);
        }
    /* public void On()
    {
        AudioListener.volume = 0;
        on.SetActive(false);
        off.SetActive(true);
    }

    public void Off()
    {
        AudioListener.volume = 1;
        on.SetActive(true);
        off.SetActive(false);
    } */

    private void Update()
    {
        if(_musicVolume <= 0)
        {
            noAudio.SetActive(true);
            Audio.SetActive(false);
        }
        else
        {
            noAudio.SetActive(false);
            Audio.SetActive(true);
        }
    }
}