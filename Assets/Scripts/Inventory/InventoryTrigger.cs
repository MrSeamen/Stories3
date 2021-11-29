using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTrigger : MonoBehaviour
{
    public Vector3 showPickupOffset;
    public float pickupTime;
    private Animator animator;
    private KeyHolder keyHolder;

    private void Awake()
    {
        animator = GameObject.Find("Player/Img").GetComponent<Animator>();
        keyHolder = GameObject.Find("InventoryManager").GetComponent<KeyHolder>();
    }

    private IEnumerator ItemPickup(GameObject key)
    {
        animator.SetBool("ObjectPickedUp", true);
        GetComponent<Move>().LockMovement(true);
        key.transform.parent = transform;
        key.transform.localPosition = showPickupOffset;

        yield return new WaitForSeconds(pickupTime);

        GameObject.Find("Pickup Audio").GetComponent<AudioSource>().Stop();
        animator.SetBool("ObjectPickedUp", false);
        GetComponent<Move>().LockMovement(false);
        Destroy(key);
    }

    private void OnTriggerEnter(Collider other)
    {
        Key key = other.GetComponent<Key>();
        if (key != null)
        {
            keyHolder.AddKey(key.GetKeyType(), key);
            GameObject.Find("Pickup Audio").GetComponent<AudioSource>().Play();
            StartCoroutine(ItemPickup(key.gameObject));
        }

        KeyDoor keyDoor = other.GetComponent<KeyDoor>();
        TransitionDoor transitionDoor = other.GetComponent<TransitionDoor>();
        FragmentDoor fragDoor = other.GetComponent<FragmentDoor>();

        if (keyDoor != null) { 
        
            if (keyHolder.ContainsKey(keyDoor.GetKeyType()))
            {
                // Currently holding key to open this door
                keyHolder.RemoveKey(keyDoor.GetKeyType());
                keyDoor.OpenDoor();
            }
        }

        if (transitionDoor != null)
        {
            if (keyHolder.ContainsKey(transitionDoor.GetKeyType()))
            {
                // Currently holding key to open this door
                keyHolder.RemoveKey(transitionDoor.GetKeyType());
                transitionDoor.SetLock(false);
                //transitionDoor.UnlockAudio();
            }
        }

        if (fragDoor != null)
        {
            if (keyHolder.ContainsKey(fragDoor.GetKeyType1()) && keyHolder.ContainsKey(fragDoor.GetKeyType2()) && keyHolder.ContainsKey(fragDoor.GetKeyType3()))
            {
                Debug.Log("You can now open the door");
                keyHolder.RemoveKey(fragDoor.GetKeyType1());
                keyHolder.RemoveKey(fragDoor.GetKeyType2());
                keyHolder.RemoveKey(fragDoor.GetKeyType3());
                fragDoor.OpenDoor();
            }
            else
            {
                Debug.Log("You do not have enough keys to open this door");
            }
        }
    }
}
