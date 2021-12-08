using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveInventoryOnAwake : MonoBehaviour
{
    private void Awake() {
        KeyHolder[] objs = FindObjectsOfType<KeyHolder>();

        foreach(KeyHolder kh in objs)
        {
            Destroy(kh.gameObject);
        }
    }
}
