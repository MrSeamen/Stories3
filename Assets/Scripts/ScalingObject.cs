using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalingObject : MonoBehaviour
{
    public GameObject gameObject;
    public Vector3 scaleChange, positionChange;
    public double lowerLimit, upperLimit;

    void Update()
    {
        transform.localScale += scaleChange;
        transform.position += positionChange;

        // Move upwards when the sphere hits the floor or downwards
        // when the sphere scale extends 1.0f.
        if (gameObject.transform.localScale.y < lowerLimit || gameObject.transform.localScale.y > upperLimit)
        {
            scaleChange = -scaleChange;
            positionChange = -positionChange;
        }
    }
}