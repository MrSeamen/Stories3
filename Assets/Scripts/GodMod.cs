using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GodMod : MonoBehaviour
{
    public bool godActivated = false;
    public GameObject[] checkPoints;

    public void Teleport(InputAction.CallbackContext context){
        if (godActivated == true && context.performed) {
            int checkPoint = (int)context.ReadValue<float>() - 1;

            try
            {
                GameObject checkPointObject = checkPoints[checkPoint];

                transform.position = checkPointObject.transform.position;
                GameObject.Find("TrackManager").GetComponent<TrackTransition>().ManuallySetTrack(1);
            } catch
            {
                Debug.Log("No such position...");
            }
        }
    }
}
