using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveKey : MonoBehaviour
{
    public Key.KeyType keyType;
    public void RemoveKeyStatic()
    {
        KeyHolder kh = GameObject.Find("InventoryManager").GetComponent<KeyHolder>();
        kh.RemoveKey(keyType);
    }
}
