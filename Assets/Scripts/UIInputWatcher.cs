using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIInputWatcher : MonoBehaviour
{
    public GameObject defaultSelected;
    private GameObject shouldSelect;

    private void Start()
    {
        shouldSelect = defaultSelected;
        PlayerInput playerInput = FindObjectOfType<PlayerInput>();
        UpdateSelect(playerInput);
    }

    public void UpdateShouldSelect(GameObject objectToSelect)
    {
        shouldSelect = objectToSelect;
        PlayerInput playerInput = FindObjectOfType<PlayerInput>();
        UpdateSelect(playerInput);
    }

    public void UpdateSelect(BaseEventData objectToSelect)
    {
        shouldSelect = objectToSelect.selectedObject;
    }

    public void UpdateSelect(PlayerInput playerInput)
    {
        string scheme = playerInput.currentControlScheme;
        PlayerPrefs.SetString("currentSchema", scheme);
        if(shouldSelect)
        {
            switch (scheme)
            {
                case "Gamepad":
                    shouldSelect.GetComponent<Selectable>().Select();
                    break;
                case "Keyboard&Mouse":
                default:
                    break;
            }
        }
    }
}
