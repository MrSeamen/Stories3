using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeBehavior : MonoBehaviour
{
    public InputSceneCube controls;

    void Awake() {
        controls.Cube.Pick.performed += _ => Picked();
        controls.Cube.Rotation.performed += context => Rotate(context.ReadValue<Vector2>());
    }

    void Picked() {
        Debug.Log("picked");
    }

    void Rotate (Vector2 direction) {
        Debug.Log("rotate on" + direction);
    }
    
    private void OnEnable() {
        controls.Enable();
    }

    public void onDisable() {
        controls.Disable();
    }
}
