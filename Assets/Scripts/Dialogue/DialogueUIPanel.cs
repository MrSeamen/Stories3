using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUIPanel : MonoBehaviour
{
    [SerializeField] float dialogSpeed = 0.025f;
    [SerializeField] Text nameBox;
    [SerializeField] Text textBox;
    [SerializeField] Image image;

    public Animator animator;

    private AudioSource audio1;
    private AudioSource audio2;

    [SerializeField] AudioSource goondalf1;
    [SerializeField] AudioSource goondalf2;
    [SerializeField] AudioSource grandma1;
    [SerializeField] AudioSource grandma2;

    private Coroutine runningRoutine;

    public void UpdateView(Sprite headImg, string name)
    {
        nameBox.text = name;
        image.sprite = headImg;
    }

    public void UpdateSentence(string text)
    {
        if (runningRoutine != null)
        {
            StopCoroutine(runningRoutine);
        }
        runningRoutine = StartCoroutine(TypeText(text));
    }

    IEnumerator TypeText(string text)
    {
        bool flip = true;
        textBox.text = "";
        foreach (char letter in text.ToCharArray())
        {
            textBox.text += letter;
            if (letter != ' ' && animator.GetBool("IsOpen"))
            {
                if (flip)
                {
                    audio1.Play();
                    flip = false;
                }
                else
                {
                    audio2.Play();
                    flip = true;
                }
            }
            yield return new WaitForSeconds(dialogSpeed);
        }
    }

    public void Goondalf()
    {
        audio1 = goondalf1;
        audio2 = goondalf2;
    }

    public void Grandma()
    {
        audio1 = grandma1;
        audio2 = grandma2;
    }
}
