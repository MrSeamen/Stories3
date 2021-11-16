using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUIPanel : MonoBehaviour
{
    [SerializeField] float continueDelay = 0.5f;
    [SerializeField] float dialogSpeed = 0.025f;
    [SerializeField] Text nameBox;
    [SerializeField] Text textBox;
    [SerializeField] Text continueBox;
    [SerializeField] Image image;
    [SerializeField] AudioSource audioSource;

    public Animator animator;

    private Coroutine runningRoutine;
    private AudioClip[] audioClips;

    public void UpdateView(Sprite headImg, string name, AudioClip[] audioClipsIn)
    {
        nameBox.text = name;
        image.sprite = headImg;
        audioClips = audioClipsIn;
    }

    public void UpdateSentence(string text)
    {
        if (runningRoutine != null)
        {
            StopCoroutine(runningRoutine);
        }
        continueBox.gameObject.SetActive(false);
        runningRoutine = StartCoroutine(TypeText(text));
    }

    IEnumerator TypeText(string text)
    {
        textBox.text = "";
        foreach (char letter in text.ToCharArray())
        {
            textBox.text += letter;
            if (letter != ' ' && animator.GetBool("IsOpen"))
            {
                audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)]);
            }
            yield return new WaitForSeconds(dialogSpeed);
        }
        yield return new WaitForSeconds(continueDelay);
        continueBox.gameObject.SetActive(true);
    }
}
