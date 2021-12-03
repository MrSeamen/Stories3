using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GodMod : MonoBehaviour
{

    public bool godActivated = false;
    public Transform teleportOne;
    public Transform teleportTwo;

    //press 1 to teleport to the middle of Level 1
    public void TeleportOne(InputAction.CallbackContext context){
        if (godActivated == true) {
            GetComponent<Rigidbody>().position = teleportOne.transform.position; 
        }
    }

    //press 2 to teleport to the end of Level 1
     public void TeleportTwo(InputAction.CallbackContext context){
        if (godActivated == true) {
            GetComponent<Rigidbody>().position = teleportTwo.transform.position; 
        }
    } 
}
