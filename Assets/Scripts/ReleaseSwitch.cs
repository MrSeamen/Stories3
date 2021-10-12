using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ReleaseSwitch : MonoBehaviour
{
    private bool trigger = false;
    public Collider collider_activatable;
    public DialogueTrigger goondalfInitialDialog;
    public DialogueTrigger goondalfFreedDialog;

    public void ColliderActivate(InputAction.CallbackContext context)
    {
        if (trigger)
        {
            collider_activatable.enabled = !collider_activatable.enabled;
            goondalfInitialDialog.gameObject.SetActive(false);
            goondalfFreedDialog.gameObject.SetActive(true);
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
