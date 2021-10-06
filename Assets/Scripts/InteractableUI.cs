using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractableUI : MonoBehaviour
{
    [SerializeField] private GameObject UI;
    private bool uiEnabled;
    private bool trigger;

    void Start()
    {
        UI.SetActive(false);
        uiEnabled = false;
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            trigger = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            trigger = false;
            UI.SetActive(false);
            uiEnabled = false;
        }
    }

    public void UIActivate(InputAction.CallbackContext context)
    {
        if (trigger && !uiEnabled)
        {
            UI.SetActive(true);
            uiEnabled = true;
        } else
        {
            UI.SetActive(false);
            uiEnabled = false;
        }
        
    }

}
