using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

 public class InventoryMove : MonoBehaviour {
    public Button button;
    public int clicked = 0;
    public bool isClicked = false; 
    public GameObject inventory; 

	void Start () {
		Button btn = button.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
        }

     void TaskOnClick(){
         isClicked = true;
          if(isClicked == true){
              inventory.transform.Translate(Vector3.right * ((clicked%2==0)?10000:-10000));
              isClicked = !isClicked;
              clicked++;
             }
         }
     }
