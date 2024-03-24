using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider sfxSlider;

    public GameObject Audio;
    public GameObject noAudio;


    void Start()
    {
        if(PlayerPrefs.HasKey("sfxVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetSFXVolume();
        }
    }

    private void Update()
    {
        if(sfxSlider.value <= 0.0001)
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

    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;
        mixer.SetFloat("sfx", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }

    private void LoadVolume()
    {
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        SetSFXVolume();
    }
}
