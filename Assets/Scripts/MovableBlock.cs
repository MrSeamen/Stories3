using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovableBlock : MonoBehaviour
{
    public GameObject player;
    public GameObject parent;
    private bool hold;
    private bool trigger;
    public Collider col;

    public Collider left;
    public Collider right;

    void Start()
    {
        this.transform.parent = parent.transform;
        hold = false;
        GetComponent<Rigidbody>().isKinematic = false;
        col.enabled = true;
        left.enabled = false;
        right.enabled = false;
    }

    public void Hold(InputAction.CallbackContext context)
    {
        if (hold)
        {
            this.transform.parent = parent.transform;
            hold = false;
            col.enabled = true;
            GetComponent<Rigidbody>().isKinematic = false;
            left.enabled = false;
            right.enabled = false;
        } else if (trigger)
        {
            this.transform.parent = player.transform;
            hold = true;
            col.enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            if (player.transform.position.x < this.transform.position.x)
            {
                right.enabled = true;
            } else {
                left.enabled = true;
            }
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player") && collider.GetComponent<Move>().OnGround())
        {
            trigger = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            trigger = false;
        }
    }
}
