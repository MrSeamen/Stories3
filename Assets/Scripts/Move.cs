using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.02f;
    [SerializeField] float jumpForce = 2.0f;

    public Vector3 _direction;
    private Vector3 jump;
    public bool isGrounded;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        if(CameraShift.getScroller())
        {
            Vector3 movement = new Vector3(_direction.x * moveSpeed, rb.velocity.y, 0);
            rb.velocity = movement;
        } else
        {
            Vector3 movement = new Vector3(_direction.x * moveSpeed, rb.velocity.y, _direction.z * moveSpeed);
            rb.velocity = movement;
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            isGrounded = false;
            Vector3 movement = jump * jumpForce;
            rb.velocity = movement;
            Debug.Log("Here: " + isGrounded);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 _inputVector = context.ReadValue<Vector2>();
        _direction = new Vector3(_inputVector.x, 0, _inputVector.y);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Jumpable"))
        {
            isGrounded = true;
            Debug.Log("Here2: " + isGrounded);
        }
    }

    public void Recenter()
    {
        if (CameraShift.getScroller() && transform.position.z != 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }
}
