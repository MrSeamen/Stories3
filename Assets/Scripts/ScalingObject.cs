using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalingObject : MonoBehaviour
{
    public float verticalShift, amplitude, phaseShift1, phaseShift2, lowerScaleLimit;

    void Update()
    {
        float scalar = Math.Abs(amplitude * Mathf.Sin(Time.time * phaseShift1 + phaseShift2)) + verticalShift;
        if (scalar < lowerScaleLimit)
        {
            ; //unfinished
        }
        Vector3 vector = new Vector3(scalar, scalar, scalar);

        transform.localScale = vector;
    }
}