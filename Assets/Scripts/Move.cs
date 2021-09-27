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
        if(CameraShift.getScroller())
        {
            Recenter();
        }
    }

    public void Movement()
    {
        if(CameraShift.getScroller())
        {
            //transform.Translate(_direction.x * moveSpeed * Time.deltaTime, _direction.y * moveSpeed * Time.deltaTime, 0);
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
            Vector3 movement = jump * jumpForce;
            rb.velocity = movement;
            isGrounded = false;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 _inputVector = context.ReadValue<Vector2>();
        _direction = new Vector3(_inputVector.x, 0, _inputVector.y);
    }

   /* void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    } */

    void OnTriggerStay(Collider collider)
    {
        if(!collider.gameObject.CompareTag("Non-Jumpable"))
        {
            isGrounded = true;
        }
    }

    void OnTriggerExit()
    {
        isGrounded = false;
    }

    public void Recenter()
    {
        if(transform.position.z != 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }
}
