using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTowardPoint : MonoBehaviour
{
    public float speed;
    public Vector3 destination = new Vector3(0f, 3f, 0f);

    public void moveTowards()
    {
        //Vector3.MoveTowards(transform.position, destination, Time.deltaTime * speed);
        transform.localPosition += destination;
    }
}
