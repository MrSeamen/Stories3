using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicL1 : MonoBehaviour
{
    private static MusicL1 instance = null;
    private AudioSource audio;
    private bool level1 = false;
    private static bool forest = false;

    public static MusicL1 Instance
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
            audio.volume = 0.0f;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        string sceneName = scene.name;
        float vol = audio.volume;

        if (!forest && sceneName == "Level 1" && vol == 0.0f)
        {
            StartCoroutine(StartFade(audio, 2.0f, 0.5f));
            level1 = true;
        }
        else if (sceneName == "Level 2" && vol == 0.5f)
        {
            StartCoroutine(StartFade(audio, 2.0f, 0.0f));
            level1 = false;
        }
        else if (sceneName == "Level 3" && vol == 0.5f)
        {
            StartCoroutine(StartFade(audio, 2.0f, 0.0f));
            level1 = false;
        }
        else if ((sceneName == "TitleScreen" || sceneName == "Transition") && vol == 0.5f)
        {
            StartCoroutine(StartFade(audio, 2.0f, 0.0f));
            level1 = false;
        } 
        else if (level1 && forest && vol == 0.5f)
        {
            StartCoroutine(StartFade(audio, 2.0f, 0.0f));
        }
        else if (level1 && !forest && vol == 0.0f)
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

    public static void SetForest(bool val)
    {
        forest = val;
    }
}
