using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractableUI : MonoBehaviour
{
    [SerializeField] private GameObject UI;
    private bool enabled;
    private bool trigger;

    void Start()
    {
        UI.SetActive(false);
        enabled = false;
    }

    void OnTriggerEnter()
    {
        trigger = true;
    }

    void OnTriggerExit()
    {
        trigger = false;
        UI.SetActive(false);
        enabled = false;
    }

    public void UIActivate(InputAction.CallbackContext context)
    {
        if (trigger && !enabled)
        {
            UI.SetActive(true);
            enabled = true;
        } else
        {
            UI.SetActive(false);
            enabled = false;
        }
        
    }

}
