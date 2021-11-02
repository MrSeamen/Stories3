using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalingObject : MonoBehaviour
{
    
    public float lowerLimit, speed, scale;

    void Update()
    {
        Vector3 vector = new Vector3(Math.Abs(speed * Mathf.Sin(Time.time * scale)) + lowerLimit, Math.Abs(speed * Mathf.Sin(Time.time * scale)) + lowerLimit, speed * Math.Abs(Mathf.Sin(Time.time * scale)) + lowerLimit);

        transform.localScale = vector;
    }
}