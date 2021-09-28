using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class cubeBehavior : MonoBehaviour
{
    public float rotateTime = 3.0f;
    private bool rotating = false;

    public void DoRotate(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                if (!rotating)
                {
                    Debug.Log("Rotate!");
                    Vector2 inputVector = context.ReadValue<Vector2>();
                    StartCoroutine(Rotate(90.0f, rotateTime, new Vector3(inputVector.x, 0, inputVector.y)));
                }
                break;
        }
    }

    public void DoPick(InputAction.CallbackContext context)
    {
        Debug.Log("Pick" + context);
    }

    private IEnumerator Rotate(float degrees, float totalTime, Vector3 direction)
    {
        if (rotating)
            yield return null;
        rotating = true;

        float rate = degrees / totalTime;
        //Start Rotate
        for (float i = 0.0f; Mathf.Abs(i) < Mathf.Abs(degrees); i += Time.deltaTime * rate)
        {
            Debug.Log("Time: " + Time.deltaTime * rate);
            transform.Rotate(direction, Time.deltaTime * rate);
            yield return null;
        }
        rotating = false;
        Debug.Log("Done Rotating!");
    }  
}