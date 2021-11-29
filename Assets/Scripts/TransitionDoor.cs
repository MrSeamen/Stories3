using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Cinemachine;

public class TransitionDoor : MonoBehaviour
{
    [SerializeField] private float spawnTime = 1.0f;
    [SerializeField] private Key.KeyType keyType;
    [SerializeField] private bool unlocked = false;
    public FadeOut fadeOut;
    private bool trigger = false;
    private Color color;
    private AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        color = Color.white;
        color.a = 0;
        StartCoroutine(SpawnDoor());
    }

    IEnumerator SpawnDoor()
    {
        while (color.a < 1)
        {
            color.a += Time.deltaTime / spawnTime;
            gameObject.GetComponent<SpriteRenderer>().color = color;
            yield return new WaitForEndOfFrame();
        }
    }

    public Key.KeyType GetKeyType()
    {
        return keyType;
    }

    public void SetLock(bool shouldLock)
    {
        unlocked = !shouldLock;
    }

    public bool IsUnlocked()
    {
        return unlocked;
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
        if (collider.gameObject.CompareTag("Player"))
        {
            trigger = false;
        }
    }

    public void UseDoor(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            UseDoor();
        }
    }

    public void UseDoor()
    {
        if (unlocked)
        {
            UnlockAudio();
            Transition();
        }
    }

    private void Transition()
    {
        if (trigger && gameObject.CompareTag("Door1"))
        {
            GameObject.Find("InventoryManager").GetComponent<KeyHolder>().previousScene = "Level 1";
            GameObject.Find("InventoryManager").GetComponent<KeyHolder>().ClearLevelKeys();
            fadeOut.Trigger("Level 2");
        } else if (trigger && gameObject.CompareTag("Door2"))
        {
            GameObject.Find("InventoryManager").GetComponent<KeyHolder>().previousScene = "Level 2";
            GameObject.Find("InventoryManager").GetComponent<KeyHolder>().ClearLevelKeys();
            fadeOut.Trigger("Level 1");
        } else if (trigger && gameObject.CompareTag("DoorEnd"))
        {
            GameObject.Find("InventoryManager").GetComponent<KeyHolder>().previousScene = "Level 1";
            GameObject.Find("InventoryManager").GetComponent<KeyHolder>().ClearLevelKeys();
            fadeOut.Trigger("End");
        }
    }
    

    public void UnlockAudio()
    {
        audio.Play();
    } 

}
