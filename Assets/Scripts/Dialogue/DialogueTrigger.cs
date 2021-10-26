using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool triggered = false;

    public void TriggerDialogue()
    {
        if(!triggered)
        {
            triggered = true;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }
}
