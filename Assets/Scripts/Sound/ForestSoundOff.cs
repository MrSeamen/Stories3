using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestSoundOff : MonoBehaviour
{
    public AudioSource audio;

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if (collider.gameObject.GetComponent<Move>().DirectionX() < 0)
            {
                StartCoroutine(StartFade(audio, 2.0f, 0.6f));
                MusicL1.SetForest(true);
            }
            else
            {
                StartCoroutine(StartFade(audio, 2.0f, 0.0f));
                MusicL1.SetForest(false);
            }
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
