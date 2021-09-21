using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyHolder : MonoBehaviour
{
    public List<Key.KeyType> keyList;
    public Image keyImage; 

    private void Awake()
    {
        keyList = new List<Key.KeyType>();
    }

    public void AddKey(Key.KeyType keyType)
    {
        Debug.Log("You have acquired: " + keyType + "!");
        keyList.Add(keyType);
        Debug.Log("add to inventory");
        
        keyImage = GameObject.FindWithTag("Key " + keyType).GetComponent<Image>();
            if (!keyImage.enabled) {
                keyImage.enabled = true; 
                keyImage.sprite = Resources.Load<Sprite>("Sprites/Items/" + keyType);
           }
       }


    public void RemoveKey(Key.KeyType keyType)
    {
        keyList.Remove(keyType);
    }


    public bool ContainsKey(Key.KeyType keyType)
    {
        return keyList.Contains(keyType);
    }

    private void OnTriggerEnter(Collider other)
    {
        Key key = other.GetComponent<Key>();
        if (key != null)
        {
            AddKey(key.GetKeyType());
            Destroy(key.gameObject);
        }

        KeyDoor keyDoor = other.GetComponent<KeyDoor>();
        if (keyDoor != null)
        {
            if (ContainsKey(keyDoor.GetKeyType())) {
                // Currently holding key to open this door
                RemoveKey(keyDoor.GetKeyType());
                keyDoor.OpenDoor();           
            }
        }
    }
}
