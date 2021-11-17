using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyHolder : MonoBehaviour
{
    private Dictionary<Key.KeyType, Sprite> keyList;
    private InventoryDialog inventoryDialog;
    public string previousScene;

    private void Awake()
    {
        KeyHolder[] objs = FindObjectsOfType<KeyHolder>();

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        keyList = new Dictionary<Key.KeyType, Sprite>();
        inventoryDialog = GameObject.Find("UI/Inventory").GetComponent<InventoryDialog>();
    }

    public void AddKey(Key.KeyType keyType, Key key)
    {
        Debug.Log("You have acquired: " + keyType + "!");
        keyList.Add(keyType, key.icon);
        Debug.Log("add to inventory");

        inventoryDialog.ShowKey(key.icon);
    }


    public void RemoveKey(Key.KeyType keyType)
    {
        Sprite sprite;
        if(keyList.TryGetValue(keyType, out sprite))
        {
            keyList.Remove(keyType);
            inventoryDialog.RemoveKey(sprite);
        }
    }


    public bool ContainsKey(Key.KeyType keyType)
    {
        return keyList.TryGetValue(keyType, out _);
    }
}
