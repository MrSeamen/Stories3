using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class cubeBehavior : MonoBehaviour
{
    private InputSceneCube inputSceneCube;
    private InputAction input; 

    private void Awake() {
        inputSceneCube = new inputSceneCube();
    }

    private void OnEnable() {
        input = inputSceneCube.Cube.Movement;
        input.Enable();

        inputSceneCube.SceneCube.Rotate.performed += DoRotate();
        inputSceneCube.SceneCube.Rotate.Enable();

        inputSceneCube.SceneCube.Pick.performed += DoPick();
        inputSceneCube.SceneCube.Pick.Enable();
    }

    private void DoRotate(InputAction.CallbackContext obj) {
        Debug.Log("Rotate" + obj);
    }

    private void DoPick(InputAction.CallbackContext obj) {
        Debug.Log("Pick" + obj);
    }

    private void OnDisable() {
        input.Disable();
        inputSceneCube.SceneCube.Rotate.Disable();
        inputSceneCube.SceneCube.Pick.Disable();
    }

    private void FixedUpdate() {
        Debug.Log("Movement Values " + input.ReadValue<Vector2>());
    }
}
