using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    private static Music instance = null;
    private AudioSource audio;

    public static Music Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        audio = GetComponent<AudioSource>();

        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
            audio.Play();
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        string sceneName = scene.name;
        float vol = audio.volume;

        if(sceneName == "Level 1" && vol == 0.5f)
        {
            StartCoroutine(StartFade(audio, 2.0f, 0.0f));
        }
        else if (sceneName == "Level 2" && vol == 0.5f)
        {
            StartCoroutine(StartFade(audio, 2.0f, 0.0f));
        }
        else if (sceneName == "Level 3" && vol == 0.5f)
        {
            StartCoroutine(StartFade(audio, 2.0f, 0.0f));
        } else if ((sceneName == "TitleScreen" || sceneName == "Transition") && vol == 0.0f)
        {
            StartCoroutine(StartFade(audio, 2.0f, 0.5f));
        }
    }

    public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }
}
