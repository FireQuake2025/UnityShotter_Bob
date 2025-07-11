using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundMix : MonoBehaviour
{
    public Slider soundSlider;
    public AudioMixer mixerMaster;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetVolume(PlayerPrefs.GetFloat("SavedMasterVolume", 100));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVolume(float volume)
    {
        if(volume < 1)
        {
            volume = .001f;
        }
        RefreshSlider(volume);
        PlayerPrefs.SetFloat("SavedMasterVolume",volume);
        mixerMaster.SetFloat("Master", Mathf.Log10(volume / 100) * 20f);
    }

    public void SetVolumeFromSlider()
    {
        SetVolume(soundSlider.value);
    }

    public void RefreshSlider(float volume)
    {
        soundSlider.value = volume;
    }

}
