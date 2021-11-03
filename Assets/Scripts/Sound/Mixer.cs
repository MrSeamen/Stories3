using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Mixer : MonoBehaviour
{
    public AudioMixer masterMixer;

    public float initialLevel = 0.0f;
    public Slider masterslider;
    public Slider musicslider;
    public Slider sfxslider;

    public AudioSource click;

    void Awake()
    {
        click.mute = true;
        masterslider.value = PlayerPrefs.GetFloat("MasterVolume", initialLevel);
        musicslider.value = PlayerPrefs.GetFloat("MusicVolume", initialLevel);
        sfxslider.value = PlayerPrefs.GetFloat("SFXVolume", initialLevel);
        click.Stop();
        click.mute = false;
    }

    public void SetSFXLevel(float sfxLevel)
    {
        masterMixer.SetFloat("sfxVol", Mathf.Log10(sfxLevel) * 20);

        PlayerPrefs.SetFloat("SFXVolume", sfxslider.value);
        PlayerPrefs.Save();

        click.Play();
    }

    public void SetMusicLevel(float musicLevel)
    {
        masterMixer.SetFloat("musicVol", Mathf.Log10(musicLevel) * 20);

        PlayerPrefs.SetFloat("MusicVolume", musicslider.value);
        PlayerPrefs.Save();

        click.Play();
    }

    public void SetMasterLevel(float masterLevel)
    {
        masterMixer.SetFloat("masterVol", Mathf.Log10(masterslider.value) * 20);

        PlayerPrefs.SetFloat("MasterVolume", masterslider.value);
        PlayerPrefs.Save();

        click.Play();
    }

}
