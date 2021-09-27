using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShift : MonoBehaviour
{
    Camera mainCamera;
    private static bool scroller;

    void Start()
    {
        mainCamera = GetComponent<Camera>();
        scroller = true;
    }

    public void Shift()
    {
        mainCamera.orthographic = !mainCamera.orthographic;
        scroller = !scroller;
    }

    public static bool getScroller()
    {
        return scroller;
    }
}
