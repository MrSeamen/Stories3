using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentSpawnDoor : MonoBehaviour
{
    public GameObject door;
    public bool turnOnDoor = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Move>())
        {
            if(turnOnDoor)
            {
                door.gameObject.SetActive(true);
            }
            door.GetComponent<TransitionDoor>().SetLock(false);
        }
    }
}
