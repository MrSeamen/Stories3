using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public AudioSource music; 
    public Slider volume; 

    void Start()
    {
        volume.value = PlayerPrefs.GetFloat("MusicVolume");
    }

    void Update() 
    {
        music.volume = volume.value;
    }

    public void VolumePrefs() 
    {
        PlayerPrefs.SetFloat("MusicVolume", music.volume);
        PlayerPrefs.Save();
    }

    void PlayMusic(){}
  
}
