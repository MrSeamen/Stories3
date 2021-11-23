using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InteractTrigger : MonoBehaviour
{
    //Could be rewritten to show/hide floating text instead of creating and deleteing;

    public GameObject FloatingTextPrefab;
    public Vector3 offsetPos;
    public Vector3 scale;
    public string lockedMessage = "Locked";
    public string defaultMessage = "(<BUTTON>) Interact";
    private GameObject FloatingTextInstance;

    public void ShowFloatingText()
    {
        Vector3 pos = offsetPos + transform.position;
        FloatingTextInstance = Instantiate(FloatingTextPrefab, transform);
        FloatingTextInstance.transform.localPosition = offsetPos;
        FloatingTextInstance.transform.localScale = scale;
        try
        {
            if (!GetComponent<TransitionDoor>().IsUnlocked())
            {
                FloatingTextInstance.GetComponentInChildren<Text>().text = lockedMessage;
            } else
            {
                PlayerInput playerInput = FindObjectOfType<PlayerInput>();
                UpdateText(playerInput);
            }
        } catch
        {
            PlayerInput playerInput = FindObjectOfType<PlayerInput>();
            UpdateText(playerInput);
        }
    }

    public void UpdateText(PlayerInput playerInput)
    {
        string scheme = playerInput.currentControlScheme;
        switch (scheme)
        {
            case "Gamepad":
                FloatingTextInstance.GetComponentInChildren<Text>().text = defaultMessage.Replace("<BUTTON>", "X");
                break;
            case "Keyboard&Mouse":
            default:
                FloatingTextInstance.GetComponentInChildren<Text>().text = defaultMessage.Replace("<BUTTON>", "E");
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (FloatingTextPrefab && !FloatingTextInstance)
            {
                ShowFloatingText();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (FloatingTextInstance)
            {
                Destroy(FloatingTextInstance);
            }
        }
    }
}

