using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GodMod : MonoBehaviour
{
    public GameObject player;
    public bool godActivated = false;
    public GameObject[] checkPoints;
    private int lastCheckpoint = -1;

    public void Teleport(InputAction.CallbackContext context){
        if (godActivated == true && context.performed && gameObject.activeInHierarchy) {
            string scheme = PlayerPrefs.GetString("currentSchema", "Keyboard&Mouse");
            
            try
            {
                int checkPoint = (int)context.ReadValue<float>();
                switch (scheme)
                {
                    case "Gamepad":
                        checkPoint = lastCheckpoint + checkPoint;
                        break;
                    case "Keyboard&Mouse":
                    default:
                        checkPoint = checkPoint - 1; 
                        break;
                }
                GameObject checkPointObject = checkPoints[checkPoint];

                player.transform.position = checkPointObject.transform.position;
                GameObject.Find("TrackManager").GetComponent<TrackTransition>().ManuallySetTrack(1);
                lastCheckpoint = checkPoint;
            } catch
            {
                Debug.Log("No such position...");
            }
        }
    }
}
