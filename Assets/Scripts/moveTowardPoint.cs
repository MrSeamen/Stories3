using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTowardPoint : MonoBehaviour
{
    public float speed;
    private Vector3 pos1;
    private Vector3 pos2;
    public Vector3 posDiff = new Vector3(0f, 0f, 0f);

    public void move()
    {
        pos1 = transform.position;
        pos2 = transform.position + posDiff;
        while (true)
        {
            transform.position = Vector3.Lerp(pos1, pos2, Time.time * speed);
        }
    }
}
