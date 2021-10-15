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

    private Coroutine runningRoutine;

    public void UpdateView(Sprite headImg, string name)
    {
        nameBox.text = name;
        image.sprite = headImg;
    }

    public void UpdateSentence(string text)
    {
        if(runningRoutine != null)
        {
            StopCoroutine(runningRoutine);
        }
        runningRoutine = StartCoroutine(TypeText(text));
    }

    IEnumerator TypeText(string text)
    {
        textBox.text = "";
        foreach(char letter in text.ToCharArray())
        {
            textBox.text += letter;
            yield return new WaitForSeconds(dialogSpeed);
        }
    }
}
