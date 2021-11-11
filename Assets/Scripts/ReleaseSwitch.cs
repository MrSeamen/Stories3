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
        if(context.performed)
        {
            if (trigger)
            {
                collider_activatable.enabled = false;
                goondalfInitialDialog.gameObject.SetActive(false);
                goondalfFreedDialog.gameObject.SetActive(true);
                Destroy(this.gameObject);
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
