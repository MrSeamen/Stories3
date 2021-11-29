using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCubeRotate : MonoBehaviour
{
    public float speed = 1.0f;
    public Vector3 pointAOffset = new Vector3(0f, 0f, 45f);
    public Vector3 pointBOffset = new Vector3(0f, 0f, -45f);

    Vector3 pointA;
    Vector3 pointB;

    void Start()
    {
        pointA = transform.eulerAngles + pointAOffset;
        pointB = transform.eulerAngles + pointBOffset;
    }

    void Update()
    {
        //PingPong between 0 and 1
        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.eulerAngles = Vector3.Lerp(pointA, pointB, time);
    }
}
