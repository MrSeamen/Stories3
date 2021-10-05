using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ReleaseSwitch : MonoBehaviour
{
    private bool trigger = false;
    public Collider collider_activatable;

    public void ColliderActivate(InputAction.CallbackContext context)
    {
        if (trigger)
        {
            collider_activatable.enabled = !collider_activatable.enabled;
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