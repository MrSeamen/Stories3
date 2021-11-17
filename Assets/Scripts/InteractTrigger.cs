using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractTrigger : MonoBehaviour
{
    //Could be rewritten to show/hide floating text instead of creating and deleteing;

    public GameObject FloatingTextPrefab;
    public Vector3 offsetPos;
    public Vector3 scale;
    public string lockedMessage = "Locked";
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
            }
        } catch
        {

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

