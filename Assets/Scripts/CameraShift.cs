using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class CameraShift : MonoBehaviour
{
    public Camera mainCamera;
    public Vector3 rotation;
    public Vector3 rotationOffset = new Vector3(10f, 0, 0);
    public Vector3 targetOffset = new Vector3(0,3f,0);
    private Matrix4x4 ortho,
                       perspective;
    public float fov = 60f,
                        near = .3f,
                        far = 1000f,
                        orthographicSize = 5f;
    private float aspect;
    //private MatrixBlender blender;
    private bool orthoOn;


    public GameObject target;
   
    public float smoothTime = 3.0f;
    private static bool scroller;

    void Start()
    {
        mainCamera = GetComponent<Camera>();
        aspect = (float)Screen.width / (float)Screen.height;
        ortho = Matrix4x4.Ortho(-orthographicSize * aspect, orthographicSize * aspect, -orthographicSize, orthographicSize, near, far);
        perspective = Matrix4x4.Perspective(fov, aspect, near, far);
        mainCamera.projectionMatrix = ortho;
        orthoOn = true;
       // blender = (MatrixBlender)GetComponent(typeof(MatrixBlender));
        target = GameObject.Find("Player");
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

          //  blender.BlendToMatrix(ortho, 1f);
          
        }
        else {


           
            StartCoroutine(MoveOverTime(perspPos, perspAngle));

          //  blender.BlendToMatrix(perspective, 1f);
        } 
    }

    public static bool getScroller()
    {
        return scroller;
    }
}
