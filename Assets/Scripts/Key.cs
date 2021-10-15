using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private KeyType keyType;
    public Sprite icon; 

    public enum KeyType
    {
        L1Main,
        L1Grandma,
        L1Door,
        L2Main,
        L2Door,
        L3Main,
        L3Fragment1,
        L3Fragment2,
        L3Fragment3
    }

    public Key(KeyType keyType) {
        this.keyType = keyType; 
        this.icon = Resources.Load<Sprite>("Sprites/Items/" + keyType);
    }

    public KeyType GetKeyType()
    {
        return keyType;
    }
}
