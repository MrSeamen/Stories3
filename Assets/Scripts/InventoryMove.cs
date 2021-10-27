using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

 public class InventoryMove : MonoBehaviour {
    public int clicked = 0;
    public bool isClicked = false; 
    public GameObject inventory; 

    public void HideInventory(InputAction.CallbackContext context){
         isClicked = true;
          if(isClicked == true){
              inventory.transform.Translate(Vector3.right * ((clicked%2==0)?10000:-10000));
              isClicked = !isClicked;
              clicked++;
             }
         }
     }
