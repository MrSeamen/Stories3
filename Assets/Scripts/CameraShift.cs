using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class CameraShift : MonoBehaviour
{
    public Cinemachine.CinemachineVirtualCamera liftedVC;
    public Cinemachine.CinemachineVirtualCamera scrollingVC;
    private Camera mainCamera;

    public Vector3 rotation;
    public Vector3 rotationOffset = new Vector3(10f, 0, 0);
    public Vector3 targetOffset = new Vector3(0, 3f, 0);
    private Matrix4x4 ortho,
                       perspective;
    public float fov = 60f,
                        near = .3f,
                        far = 1000f,
                        orthographicSize = 5f;
    private float aspect;
    private MatrixBlender blender;
    private bool orthoOn;

    public AudioSource audioSource;
    public AudioClip shift1;
    public AudioClip shift2;

    public float smoothTime = 3.0f;
    private static bool scroller;
    public bool showText = false;

    private bool shift;

    void Awake()
    {
        liftedVC.Priority = 0;
        scrollingVC.Priority = 1;
        mainCamera = Camera.main;
        aspect = (float)Screen.width / (float)Screen.height;
        ortho = Matrix4x4.Ortho(-orthographicSize * aspect, orthographicSize * aspect, -orthographicSize, orthographicSize, near, far);
        perspective = Matrix4x4.Perspective(fov, aspect, near, far);
        mainCamera.projectionMatrix = ortho;
        orthoOn = true;
        blender = (MatrixBlender)GetComponent(typeof(MatrixBlender));
        scroller = true;
        shift = true;
    }

    public void Shift(InputAction.CallbackContext context)
    {
        if(context.performed && shift && GameObject.Find("Player").GetComponent<Move>().OnGround() && !GameObject.Find("Player").GetComponent<Move>().getLock())
        {
            orthoOn = !orthoOn;
            scroller = !scroller;
            if (orthoOn)
            {
                liftedVC.Priority = 0;
                scrollingVC.Priority = 1;
                blender.BlendToMatrix(ortho, 1f);

                audioSource.clip = shift2;
                audioSource.PlayOneShot(shift2);
            }
            else
            {
                GameObject.Find("Player").GetComponent<Move>().StopMovement();
                liftedVC.Priority = 1;
                scrollingVC.Priority = 0;
                blender.BlendToMatrix(perspective, 1f);

                audioSource.PlayOneShot(shift1);
            }
        }
    }

    public void ForcedShift()
    {
        if (GameObject.Find("Player").GetComponent<Move>().OnGround() && shift && !GameObject.Find("Player").GetComponent<Move>().getLock())
        {
            orthoOn = !orthoOn;
            scroller = !scroller;
            if (orthoOn)
            {
                liftedVC.Priority = 0;
                scrollingVC.Priority = 1;
                blender.BlendToMatrix(ortho, 1f);

                audioSource.clip = shift2;
                audioSource.Play();
            }
            else
            {
                GameObject.Find("Player").GetComponent<Move>().StopMovement();
                liftedVC.Priority = 1;
                scrollingVC.Priority = 0;
                blender.BlendToMatrix(perspective, 1f);

                audioSource.clip = shift1;
                audioSource.Play();
            }
        }
    }

    public static bool getScroller()
    {
        return scroller;
    }

    void OnGUI()
    {
        if (showText)
        {
            GUI.contentColor = Color.black;
            GUI.skin.label.fontSize = 20;
            GUI.Label(new Rect(0, 0, 100, 50), "3D Mode");
        }
    }

    public void ToggleShift(bool toggle)
    {
        shift = toggle;
    }

}