using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

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
    public IEnumerator MoveOverTime(Vector3 endPos, Vector3 endAngle)
    {
        float timer = 0.0f;
        float seconds = 1;
        float percent;
        Vector3 startPos = transform.position;
        Vector3 startAngle = transform.eulerAngles;

        while (timer <= seconds)
        {
            timer += Time.deltaTime;
            percent = timer / seconds;
            transform.position = Vector3.Lerp(startPos, endPos, percent);
            transform.eulerAngles = Vector3.Lerp(startAngle, endAngle, percent);
            yield return new WaitForEndOfFrame();

        }
        transform.position = endPos;
        transform.eulerAngles = endAngle;
    }

    public void Shift(InputAction.CallbackContext context)
    {
        Vector3 orthAngle = new Vector3(0, 0, 0);
        Vector3 perspAngle = new Vector3(45, 0, 0);
        Vector3 orthPos = new Vector3(0, 0, -10) + target.transform.position;
        Vector3 perspPos = new Vector3(0, 10, -10) + target.transform.position;

        
        orthoOn = !orthoOn;
        scroller = !scroller;
        if (orthoOn)
        {
           
            StartCoroutine(MoveOverTime(orthPos, orthAngle));

            blender.BlendToMatrix(ortho, 1f);
          
        }
        else {
            StartCoroutine(MoveOverTime(perspPos, perspAngle));

            blender.BlendToMatrix(perspective, 1f);
        }
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
