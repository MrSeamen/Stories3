using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnSentenceEvent : UnityEvent { }

[System.Serializable]
public struct DialogueEvents
{
    [TextArea(3, 5)]
    public string sentence;
    public OnSentenceEvent sentenceEvent;
}


[System.Serializable]
public class Dialogue
{
    public Sprite headImg;
    public string name;
    public AudioClip[] audio;

    [SerializeField]
    public DialogueEvents[] dialogueEvents;
}
