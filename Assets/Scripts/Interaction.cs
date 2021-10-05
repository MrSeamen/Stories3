using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    [SerializeField] private string text; 
    private bool show = false;

    void Start() {
        show = false;
    }
    

    void OnCollisionEnter(Collision collision) {
        Debug.Log("Collide");
        if (collision.gameObject.tag == "Player") {
            Debug.Log("playerfound");
            show = true; 
            }
    }
    void OnCollisionExit(Collision collision) {
      if (collision.gameObject.tag == "Player") {
          show = false;
        }
    }
    void OnGUI(){
        if (show) {
            GUI.contentColor = Color.black;
            GUI.skin.label.fontSize = 20;
            GUI.Label(new Rect(Screen.width/2 - 50, Screen.height/2 + 50, 100, 50), text);
        }
    }
}
