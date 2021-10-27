using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume : MonoBehaviour
{
    public SoundManager.SoundType soundType;
    public bool shouldUpdate = false;
    private AudioSource music;
    private void Awake()
    {
        music = GetComponent<AudioSource>();
    }

    void Start()
    {
        UpdateVolume();
    }

    void Update()
    {
        if(shouldUpdate)
        {
            UpdateVolume();
        }
    }

    void UpdateVolume()
    {
        music.volume = PlayerPrefs.GetFloat(soundType.ToString() + "Volume");
    }
}
