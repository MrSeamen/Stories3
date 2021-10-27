using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractTrigger : MonoBehaviour
{
    //Could be rewritten to show/hide floating text instead of creating and deleteing;

    public GameObject FloatingTextPrefab;
    public Vector3 offsetPos;
    public Vector3 scale;
    private GameObject FloatingTextInstance;

    public void ShowFloatingText()
    {
        Debug.Log("Show Pick Up Text");
        Vector3 pos = offsetPos + transform.position;
        FloatingTextInstance = Instantiate(FloatingTextPrefab, new Vector3(pos.x, pos.y, pos.z), Quaternion.identity, transform);
        FloatingTextInstance.transform.localScale = scale;
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

