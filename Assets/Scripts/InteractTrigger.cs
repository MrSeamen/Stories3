using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractTrigger : MonoBehaviour
{
    //Could be rewritten to show/hide floating text instead of creating and deleteing;

    public GameObject FloatingTextPrefab;
    public Vector3 pos;
    private GameObject FloatingTextInstance;

    public void ShowFloatingText()
    {
        Debug.Log("Show Pick Up Text");
        pos = transform.position;
        FloatingTextInstance = Instantiate(FloatingTextPrefab, new Vector3(pos.x, pos.y + 0.5f * pos.y, pos.z), Quaternion.identity, transform);
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

