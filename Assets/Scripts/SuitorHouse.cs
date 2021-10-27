using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuitorHouse : MonoBehaviour
{
    private bool trigger = false;
    private bool complete;

    void Start()
    {
        this.complete = false;
    }

    public void SuitorSwap()
    {
        if(trigger & !this.complete & (FakeItems.getItems() > 0))
        {
            FakeItems.ItemSwap();
            RealItems.ItemSwap();
            this.complete = true;
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            trigger = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        trigger = false;
    }
}
