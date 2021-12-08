using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private KeyType keyType;
    public Sprite icon; 

    public enum KeyType
    {
        L1First,
        L1Second,
        L1Grandma,
        L1End,
        L2First,
        L2Second,
        L2End,
        IOU,
        SpellFragment1,
        SpellFragment2
    }

    public KeyType GetKeyType()
    {
        return keyType;
    }
}
