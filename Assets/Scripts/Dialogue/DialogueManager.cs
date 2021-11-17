using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public string dialogueActionMap = "Dialogue";
    public string playerActionMap = "Player";
    private DialogueUIPanel dialogueUIPanel;
    private Animator animator;
    static DialogueManager dialogueManager;

    private Queue<string> sentences;
    private Queue<OnSentenceEvent> onSentenceEvents;
    private OnSentenceEvent nextEvent = null;
    private Dialogue lastDialogueConfiguration = null;

    void Start()
    {
        sentences = new Queue<string>();
        onSentenceEvents = new Queue<OnSentenceEvent>();
        dialogueUIPanel = GameObject.Find("UI/DialogOverlay").GetComponent<DialogueUIPanel>();
        animator = dialogueUIPanel.gameObject.GetComponent<Animator>();
        if(dialogueManager)
        {
            throw new System.Exception("Only 1 dialog manager can be used in a scene!");
        } else
        {
            dialogueManager = this;
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        lastDialogueConfiguration = dialogue;
        dialogueUIPanel.UpdateView(dialogue.headImg, dialogue.name, dialogue.audio);
        animator.SetBool("IsOpen", true);

        PlayerInput playerInput = FindObjectOfType<PlayerInput>();
        playerInput.SwitchCurrentActionMap(dialogueActionMap);

        sentences.Clear();

        foreach (DialogueEvents dialogueEvent in dialogue.dialogueEvents)
        {
            onSentenceEvents.Enqueue(dialogueEvent.sentenceEvent);
            sentences.Enqueue(dialogueEvent.sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(dialogueUIPanel.IsWritting())
        {
            dialogueUIPanel.SkipWritting();
            return;
        }

        if (nextEvent != null)
        {
            nextEvent.Invoke();
        }

        if (sentences.Count == 0)
        {
            EndDialogue();
            nextEvent = null;
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueUIPanel.UpdateSentence(sentence);
        nextEvent = onSentenceEvents.Dequeue();
    }

    public void DisplayNextSentence(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            DisplayNextSentence();
        }
    }

    public void RestartDialogue(InputAction.CallbackContext context)
    {
        if (context.performed && lastDialogueConfiguration != null)
        {
            StartDialogue(lastDialogueConfiguration);
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        PlayerInput playerInput = FindObjectOfType<PlayerInput>();
        playerInput.SwitchCurrentActionMap(playerActionMap);
    }
}
