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

    private bool flipped;

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
        trigger = false;
        audioSource.Stop();
        flipped = false;
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

        //Audio
        if (hold && player.GetComponent<Move>().isMoving() && !audioSource.isPlaying && player.GetComponent<Move>().OnGround())
        {
            audioSource.Play();
        } else if (trigger && !hold && player.GetComponent<Move>().isMoving() && !audioSource.isPlaying && (direction == player.GetComponent<Move>().DirectionX()))
        {
            audioSource.Play();
        } else if ((!trigger || !player.GetComponent<Move>().isMoving()))
        {
            audioSource.Pause();
        } else if (hold && !player.GetComponent<Move>().OnGround())
        {
            audioSource.Pause();
        }

        //Animations: flipping and changing from push to pull while holding
        if (hold && player.GetComponent<Move>().isMoving() && (direction * player.GetComponent<Move>().DirectionX()) > 0)
        {
            player.GetComponent<Move>().TogglePush(true);
            if (flipped)
            {
                this.transform.parent = parent.transform;
                player.GetComponent<Move>().Flip();
                this.transform.parent = player.transform;
            }
            flipped = false;
        }
        else if (hold && player.GetComponent<Move>().isMoving())
        {
            player.GetComponent<Move>().TogglePull(true);
            if (!flipped)
            {
                this.transform.parent = parent.transform;
                player.GetComponent<Move>().Flip();
                this.transform.parent = player.transform;
            }
            flipped = true;
        }

        //Animations: when to hold or push
        if (hold && !pastHold)
        {
            player.GetComponent<Move>().TogglePull(true);
        }
        else if (!hold && pastHold)
        {
            player.GetComponent<Move>().TogglePull(false);
        }
        else if (trigger && !hold && player.GetComponent<Move>().isMoving() && (direction * player.GetComponent<Move>().DirectionX()) > 0)
        {
            player.GetComponent<Move>().TogglePush(true);
        }
        else if (pastTrigger && !trigger)
        {
            player.GetComponent<Move>().TogglePush(false);
            player.GetComponent<Move>().TogglePull(false);
        } 
        else if (trigger && !hold && (!player.GetComponent<Move>().isMoving() || (direction != player.GetComponent<Move>().DirectionX())))
        {
            player.GetComponent<Move>().TogglePush(false);
        }

        //Animations: when to pause while holding
        if (hold && player.GetComponent<Move>().isMoving())
        {
            player.GetComponent<Move>().PauseAnimation(false);
        } 
        else if (hold)
        {
            player.GetComponent<Move>().PauseAnimation(true);
        } 
        else if (!hold)
        {
            player.GetComponent<Move>().PauseAnimation(false);
            if(flipped)
            {
                player.GetComponent<Move>().Flip();
            }
            flipped = false;
        }



        pastHold = hold;
        pastTrigger = trigger;
    }

    public void Hold(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            if (hold)
            {
                GameObject.Find("Main Camera").GetComponent<CameraShift>().ToggleShift(true);
                this.transform.parent = parent.transform;
                hold = false;
                col.enabled = true;
                GetComponent<Rigidbody>().isKinematic = false;
                left.enabled = false;
                right.enabled = false;
            }
            else if (trigger && !player.GetComponent<Move>().OnRock())
            {
                GameObject.Find("Main Camera").GetComponent<CameraShift>().ToggleShift(false);
                this.transform.parent = player.transform;
                hold = true;
                col.enabled = false;
                GetComponent<Rigidbody>().isKinematic = true;
                if (player.transform.position.x < this.transform.position.x)
                {
                    right.enabled = true;
                }
                else
                {
                    left.enabled = true;
                }
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
