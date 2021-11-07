using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTowardPoint : MonoBehaviour
{
    public float speed;
    public Vector3 destination;

    public void moveTowards()
    {             
        transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * speed);
    }
}
