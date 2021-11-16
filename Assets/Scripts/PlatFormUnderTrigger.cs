using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatFormUnderTrigger : MonoBehaviour
{
    public Collider platform;
    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
       {
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
