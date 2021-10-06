using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraShift : MonoBehaviour
{
    Camera mainCamera;
    private static bool scroller;
    public bool showText = false;

    void Start()
    {
        mainCamera = GetComponent<Camera>();
        scroller = true;
    }

    public void Shift()
    {
        mainCamera.orthographic = !mainCamera.orthographic;
        scroller = !scroller;
        showText = !showText;
   
    }

    public static bool getScroller()
    {
        return scroller;
    }

     void OnGUI(){
        if (showText) {
            GUI.contentColor = Color.black;
            GUI.skin.label.fontSize = 20;
            GUI.Label(new Rect(0,0,100,50), "3D Mode");
        }
    }
}
