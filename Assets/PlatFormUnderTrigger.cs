using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatFormUnderTrigger : MonoBehaviour
{
    public Collider platform;
    
    private void OnTriggernEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
       {
            Debug.Log("Player entered trigger");
            Physics.IgnoreCollision(collider, platform, true );
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Physics.IgnoreCollision(collider, platform, false);
        }
    }
}
