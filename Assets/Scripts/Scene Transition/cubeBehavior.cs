using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class cubeBehavior : MonoBehaviour
{
    private InputSceneCube inputSceneCube;
    private InputAction inputRotate; 
    private InputAction inputPick; 
    [SerializeField]

    private void Awake() {
        inputSceneCube = new InputSceneCube();
    }

    private void OnEnable() {
        inputRotate = inputSceneCube.SceneCube.Rotate;
        inputRotate.Enable();

        inputSceneCube.SceneCube.Rotate.performed += DoRotate();
        inputSceneCube.SceneCube.Rotate.Enable();

        inputPick = inputSceneCube.SceneCube.Pick;
        inputPick.Enable();

        inputSceneCube.SceneCube.Pick.performed += DoPick();
        inputSceneCube.SceneCube.Pick.Enable();
    }

    private Action<InputAction.CallbackContext> DoRotate(InputAction.CallbackContext context) {
        Debug.Log("Rotate" + context);
        throw new NotImplementedException();
    }

    private Action<InputAction.CallbackContext> DoPick(InputAction.CallbackContext context) {
        Debug.Log("Pick" + context);
        throw new NotImplementedException();
    }

    private void OnDisable() {
        inputRotate.Disable();
        inputPick.Disable();
        inputSceneCube.SceneCube.Rotate.Disable();
        inputSceneCube.SceneCube.Pick.Disable();
    }

    private void FixedUpdate() {
        Debug.Log("Movement Values " + inputRotate.ReadValue<Vector2>());
    }
}
