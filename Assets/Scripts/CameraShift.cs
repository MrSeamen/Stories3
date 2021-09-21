using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShift : MonoBehaviour
{
    Camera mainCamera;

    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    public void Shift()
    {
        mainCamera.orthographic = !mainCamera.orthographic;
    }
}
