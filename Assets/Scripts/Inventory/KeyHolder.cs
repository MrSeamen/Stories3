using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyHolder : MonoBehaviour
{
    private Dictionary<Key.KeyType, Sprite> keyList;
    public string previousScene;

    private void Awake()
    {
        KeyHolder[] objs = FindObjectsOfType<KeyHolder>();

        if (objs.Length > 1)
        {
            objs[0].RefreshUI();
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        keyList = new Dictionary<Key.KeyType, Sprite>();
    }

    public void AddKey(Key.KeyType keyType, Key key)
    {
        Debug.Log("You have acquired: " + keyType + "!");
        keyList.Add(keyType, key.icon);
        Debug.Log("add to inventory");

        InventoryDialog inventoryDialog = GameObject.Find("UI/Inventory").GetComponent<InventoryDialog>();
        inventoryDialog.ShowKey(key.icon);
    }

    public void RefreshUI()
    {
        InventoryDialog inventoryDialog = GameObject.Find("UI/Inventory").GetComponent<InventoryDialog>();
        foreach (var item in keyList)
        {
            inventoryDialog.ShowKey(item.Value);
        }
    }


    public void RemoveKey(Key.KeyType keyType)
    {
        Sprite sprite;
        if(keyList.TryGetValue(keyType, out sprite))
        {
            keyList.Remove(keyType);
            InventoryDialog inventoryDialog = GameObject.Find("UI/Inventory").GetComponent<InventoryDialog>();
            inventoryDialog.RemoveKey(sprite);
        }
    }


    public bool ContainsKey(Key.KeyType keyType)
    {
        return keyList.TryGetValue(keyType, out _);
    }
}
