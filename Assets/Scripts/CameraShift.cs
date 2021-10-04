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
                        orthographicSize = 50f;
    private float aspect;
    private MatrixBlender blender;
    private bool orthoOn;
    public bool YMaxEnabled = false;
    public float YMaxValue = 0;
    public bool YMinEnabled = false;
    public float YMinValue = 0;
    public bool XMaxEnabled = false;
    public float XMaxValue = 0;

    public bool XMinEnabled = false;
    public float XMinValue = 0;
    public Transform cameraPos;
    public GameObject target;
   // public Transform lookAt;
    public float smoothTime = 0.0f;
    //Vector3 targetPos;
    Vector3 velocity = Vector3.zero;

    /**
    private void FixedUpdate()
    {
        //targetPos = lookAt.position;
        /**
        Vector3 targetPos = lookAt.position;
        transform.LookAt(target.transform.position + targetOffset); targetPos = lookAt.position;
       if (YMinEnabled && YMaxEnabled)
        {
            targetPos.y = Mathf.Clamp(lookAt.position.y, YMinValue, YMaxValue);
        }
        else if (YMinEnabled)
        {
            targetPos.y = Mathf.Clamp(lookAt.position.y, YMinValue, lookAt.position.y);
        }
        else if (YMaxEnabled)
        {
            targetPos.y = Mathf.Clamp(lookAt.position.y, lookAt.position.y, YMaxValue);
        }

        if (XMinEnabled && XMaxEnabled)
        {
            targetPos.y = Mathf.Clamp(lookAt.position.x, XMinValue, XMaxValue);
        }
        else if (XMinEnabled)
        {
            targetPos.x = Mathf.Clamp(lookAt.position.x, XMinValue, lookAt.position.x);
        }
        else if (YMaxEnabled)
        {
            targetPos.x = Mathf.Clamp(lookAt.position.x, lookAt.position.x, XMaxValue);
        }

        targetPos.z = transform.position.z;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
       
        
       // transform.LookAt(target.transform.position + targetOffset);
 
        //transform.rotation = transform.rotation + rotationOffset; 
    } **/
    void Start()
    {
        mainCamera = GetComponent<Camera>();
        //cameraPos = GetComponent<Transform>();
        aspect = (float)Screen.width / (float)Screen.height;
        ortho = Matrix4x4.Ortho(-orthographicSize * aspect, orthographicSize * aspect, -orthographicSize, orthographicSize, near, far);
        perspective = Matrix4x4.Perspective(fov, aspect, near, far);
        mainCamera.projectionMatrix = ortho;
        orthoOn = true;
        blender = (MatrixBlender)GetComponent(typeof(MatrixBlender));
        target = GameObject.Find("Player");
       // lookAt = gameObject.GetComponent<Transform>();
       
    }

    public void Shift()
    {
        
        orthoOn = !orthoOn;
        if (orthoOn)
        {
            // cameraPos.Rotate(target.transform.position);

            //cameraPos.LookAt(target.transform.position);
            transform.eulerAngles = new Vector3(0, 0, 0);
            //transform.position = target.transform.position + new Vector3(0, 0, -10);
            transform.position = target.transform.position + new Vector3(0, 0, -10);

            blender.BlendToMatrix(ortho, 1f);
          
        }
        else
        {

            //transform.position = lookAt.position + targetOffset;
            //cameraPos.Rotate(target.transform.position + new Vector3(12, 0, 0));
            //cameraPos.LookAt(target.transform.position + targetOffset);
            //rotation.x += 10 * 10 * Time.deltaTime;
            transform.eulerAngles = new Vector3(45, 0, 0);
            transform.position = target.transform.position + new Vector3(0, 10, -10);
            blender.BlendToMatrix(perspective, 1f);
        } 
       // mainCamera.orthographic = !mainCamera.orthographic;
    }
}
