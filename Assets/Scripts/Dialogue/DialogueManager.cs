using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public string dialogueActionMap = "Dialogue";
    public string playerActionMap = "Player";
    public DialogueUIPanel dialogueUIPanel;
    public Animator animator;


    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueUIPanel.UpdateView(dialogue.headImg, dialogue.name);
        animator.SetBool("IsOpen", true);

        PlayerInput playerInput = FindObjectOfType<PlayerInput>();
        playerInput.SwitchCurrentActionMap(dialogueActionMap);

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueUIPanel.UpdateSentence(sentence);
    }

    public void DisplayNextSentence(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            DisplayNextSentence();
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        PlayerInput playerInput = FindObjectOfType<PlayerInput>();
        playerInput.SwitchCurrentActionMap(playerActionMap);
    }
}
