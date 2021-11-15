using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTowardPoint : MonoBehaviour
{
    public float speed;
    public Vector3 destination = new Vector3(0f, 3f, 0f);
    private Vector3 currentPosition;
    private bool activate = false;

    public void moveTowards()
    {
        //transform.localPosition += destination;
        currentPosition = transform.position;
        destination += currentPosition;
        activate = true;
    }

    private void FixedUpdate()
    {
        if (activate)
        {
            transform.position = Vector3.Lerp(currentPosition, destination, Time.time*speed);
        }
    }
}
