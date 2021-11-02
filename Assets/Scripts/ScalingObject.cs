using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalingObject : MonoBehaviour
{
    
    public float verticalShift, amplitude, phaseShift, lowerScaleLimit;

    void Update()
    {
        float scalar = Math.Abs(amplitude * Mathf.Sin(Time.time * phaseShift)) + verticalShift;
        if (scalar < lowerScaleLimit)
        {
            ;
        }
        Vector3 vector = new Vector3(scalar, scalar, scalar);

        transform.localScale = vector;
    }
}