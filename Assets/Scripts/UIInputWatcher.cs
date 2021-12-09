using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIInputWatcher : MonoBehaviour
{
    public GameObject quitButton;
    public GameObject defaultSelected;
    private GameObject shouldSelect;

    private void Start()
    {
        if(Application.platform == RuntimePlatform.WebGLPlayer) {
            quitButton.SetActive(false);
        }

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
        switch (scheme)
        {
            case "Gamepad":
                Cursor.visible = false;
                break;
            case "Keyboard&Mouse":
            default:
                Cursor.visible = true;
                break;
        }
        if (shouldSelect)
        {
            switch (scheme)
            {
                case "Gamepad":
                    shouldSelect.GetComponent<Selectable>().Select();
                    break;
                case "Keyboard&Mouse":
                default:
                    GetComponent<EventSystem>().SetSelectedGameObject(null);
                    break;
            }
        }
    }
}
