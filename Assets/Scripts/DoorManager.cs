using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public Rigidbody player;
    public GameObject door1;
    public GameObject door2;
    public GameObject door3;

    void Start()
    {
        if (LevelSelection.getDoor() == 1)
        {
            player.position = door1.transform.position;
        }
        else if (LevelSelection.getDoor() == 2)
        {
            player.position = door2.transform.position;
        }
        else if (LevelSelection.getDoor() == 3)
        {
            player.position = door3.transform.position;
        }
    }
}
