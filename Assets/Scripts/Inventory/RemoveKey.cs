using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveKey : MonoBehaviour
{
    public Key.KeyType keyType;
    public void RemoveKeyStatic()
    {
        KeyHolder[] objs = FindObjectsOfType<KeyHolder>();

        if (objs.Length > 0)
        {
            objs[0].RemoveKey(keyType);
        }
    }
}
