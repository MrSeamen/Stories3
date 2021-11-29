using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentSpawnDoor : MonoBehaviour
{
    public GameObject door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Move>())
        {
            door.gameObject.SetActive(true);
            door.GetComponent<TransitionDoor>().SetLock(false);
        }
    }
}
