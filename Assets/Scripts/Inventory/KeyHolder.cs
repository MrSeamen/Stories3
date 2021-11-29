using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyHolder : MonoBehaviour
{
    private List<Key.KeyType> levelKeyList;
    private Dictionary<Key.KeyType, Sprite> keyList;
    public string previousScene;

    private void Awake()
    {
        KeyHolder[] objs = FindObjectsOfType<KeyHolder>();

        if (objs.Length > 1)
        {
            foreach(KeyHolder kh in objs)
            {
                if(kh.IsInit())
                {
                    kh.ResetLevelKeys();
                    kh.RefreshUI();
                }
            }
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
        keyList = new Dictionary<Key.KeyType, Sprite>();
        levelKeyList = new List<Key.KeyType>();
    }

    public bool IsInit()
    {
        return (levelKeyList != null && keyList != null);
    }

    public void ClearLevelKeys()
    {
        levelKeyList = new List<Key.KeyType>();
    }

    public void AddKey(Key.KeyType keyType, Key key)
    {
        Debug.Log("You have acquired: " + keyType + "!");
        keyList.Add(keyType, key.icon);
        levelKeyList.Add(keyType);
        Debug.Log("add to inventory");

        InventoryDialog inventoryDialog = GameObject.Find("UI/Inventory").GetComponent<InventoryDialog>();
        inventoryDialog.ShowKey(key.icon);
    }

    public void ResetLevelKeys()
    {
        foreach (Key.KeyType keyType in levelKeyList)
        {
            RemoveKey(keyType);
        }

        levelKeyList = new List<Key.KeyType>();
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

    public void RemoveIOU()
    {
        RemoveKey(Key.KeyType.IOU);
    }


    public bool ContainsKey(Key.KeyType keyType)
    {
        return keyList.TryGetValue(keyType, out _);
    }
}
