using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnTriggerEvent : UnityEvent { }

public class StartFlow : MonoBehaviour
{
    public OnTriggerEvent OnTrigger;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            OnTrigger.Invoke();
        }
    }
}
