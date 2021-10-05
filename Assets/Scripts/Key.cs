using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private KeyType keyType;
    public Sprite icon; 

    public enum KeyType
    {
        Main,
        Grandma,
        L2
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
