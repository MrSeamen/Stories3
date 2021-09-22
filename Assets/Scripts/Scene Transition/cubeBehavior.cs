using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class cubeBehavior : MonoBehaviour
{
    //private InputSceneCube inputSceneCube;
    private InputAction inputRotate; 
    private InputAction inputPick;
    private Vector3 direction;
    [SerializeField] float rotationDegree = 22.0f;

    /*private void Awake() {
        inputSceneCube = new InputSceneCube();
    }

    private void OnEnable() {
        inputRotate = inputSceneCube.SceneCube.Rotate;
        inputRotate.Enable();

        //inputSceneCube.SceneCube.Rotate.performed += DoRotate();
        inputSceneCube.SceneCube.Rotate.Enable();

        inputPick = inputSceneCube.SceneCube.Pick;
        inputPick.Enable();

        //inputSceneCube.SceneCube.Pick.performed += DoPick();
        inputSceneCube.SceneCube.Pick.Enable();
    }*/

    public void DoRotate(InputAction.CallbackContext context) {
        Debug.Log("Rotate" + context);
        Vector2 inputVector = context.ReadValue<Vector2>();
        direction = new Vector3(inputVector.x, 0, inputVector.y);
    }

    public void DoPick(InputAction.CallbackContext context) {
        Debug.Log("Pick" + context);
    }

    /*private void OnDisable() {
        inputRotate.Disable();
        inputPick.Disable();
        inputSceneCube.SceneCube.Rotate.Disable();
        inputSceneCube.SceneCube.Pick.Disable();
    }*/

    private void FixedUpdate() {
        //Debug.Log("Movement Values " + inputRotate.ReadValue<Vector2>());
        transform.Rotate(direction * Time.deltaTime * rotationDegree);
    }
}
