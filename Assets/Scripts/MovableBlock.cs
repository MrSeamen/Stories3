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

    public AudioSource audioSource;

    private float direction;
    private bool pastHold;
    private bool pastTrigger;

    void Start()
    {
        this.transform.parent = parent.transform;
        hold = false;
        GetComponent<Rigidbody>().isKinematic = false;
        col.enabled = true;
        left.enabled = false;
        right.enabled = false;
        pastHold = false;
        pastTrigger = false;
    }

    void Update()
    {
        if(player.transform.position.x < this.transform.position.x)
        {
            direction = 1f;
        } else
        {
            direction = -1f;
        }
        
        if (hold && hold != pastHold && player.GetComponent<Move>().isMoving() && !audioSource.isPlaying && player.GetComponent<Move>().OnGround())
        {
            audioSource.Play();
            player.GetComponent<Move>().TogglePull(true);
        } else if (trigger && trigger != pastTrigger && !hold && player.GetComponent<Move>().isMoving() && !audioSource.isPlaying && (direction == player.GetComponent<Move>().DirectionX()))
        {
            audioSource.Play();
            player.GetComponent<Move>().TogglePush(true);
        } else if (trigger != pastTrigger && (!trigger || !player.GetComponent<Move>().isMoving()))
        {
            audioSource.Pause();
            player.GetComponent<Move>().TogglePull(false);
            player.GetComponent<Move>().TogglePush(false);
        } else if (hold && hold != pastHold && !player.GetComponent<Move>().OnGround())
        {
            audioSource.Pause();
            player.GetComponent<Move>().TogglePull(false);
            player.GetComponent<Move>().TogglePush(false);
        }

        pastHold = hold;
        pastTrigger = trigger;
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
        if (collider.gameObject.CompareTag("Player") && collider.gameObject.GetComponent<Move>().OnGround())
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
