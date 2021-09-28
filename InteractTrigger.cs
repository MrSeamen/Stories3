using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractTrigger : MonoBehaviour
{
    public GameObject FloatingTextPrefab;
    public Vector3 pos;

    public void ShowFloatingText()
    {
        Debug.Log("Show Pick Up Text");
        pos = transform.position;
        Instantiate(FloatingTextPrefab, new Vector3(pos.x, pos.y + 0.5f * pos.y, pos.z), Quaternion.identity, transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (FloatingTextPrefab)
        {
            ShowFloatingText();
        }
    }
}

