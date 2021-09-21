using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShift : MonoBehaviour
{
    Camera camera;

    void Start()
    {
        camera = GetComponent<Camera>();
    }

    public void Shift()
    {
        camera.orthographic = !camera.orthographic;
    }
}
