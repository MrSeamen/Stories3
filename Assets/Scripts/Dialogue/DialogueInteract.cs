using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueInteract : MonoBehaviour
{
    public Dialogue dialogue;
    private bool trigger = false;

    public void TriggerDialogue(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            if (trigger)
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            }
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            trigger = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            trigger = false;
        }
    }
}
