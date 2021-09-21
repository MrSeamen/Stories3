using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private KeyType keyType;

    public enum KeyType
    {
        Main,
        Grandma,
        L2
    }

    public KeyType GetKeyType()
    {
        return keyType;
    }
}
