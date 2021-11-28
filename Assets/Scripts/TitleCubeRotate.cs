using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCubeRotate : MonoBehaviour
{
    public float speed = 1.0f;
    public Transform rotateOrigin;

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(rotateOrigin.position, Vector3.forward, Time.deltaTime * speed);
    }
}
