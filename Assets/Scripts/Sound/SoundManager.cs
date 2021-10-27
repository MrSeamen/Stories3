using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public enum SoundType
    {
        Master,
        Music,
        SFX
    };

    public SoundType soundType;
    public float initialLevel = 1.0f;
    private Slider slider;
    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat(soundType.ToString() + "Volume", initialLevel);
        slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    void ValueChangeCheck()
    {
        if(soundType.ToString() == "Master")
        {
            AudioListener.volume = slider.value;
        } else
        {
            PlayerPrefs.SetFloat(soundType.ToString() + "Volume", slider.value);
            PlayerPrefs.Save();
        }
    }
  
}
