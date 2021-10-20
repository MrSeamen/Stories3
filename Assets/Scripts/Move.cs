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

    public GameObject door1;
    public GameObject door2;
    public GameObject door3;

    public AudioSource walking;
    public AudioSource jumping;
    public AudioSource landing;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        if(LevelSelection.getDoor() == 1)
        {
            rb.position = door1.transform.position;
        }
        else if (LevelSelection.getDoor() == 2)
        {
            rb.position = door2.transform.position;
        } else if (LevelSelection.getDoor() == 3)
        {
            rb.position = door3.transform.position;
        }

        walking.mute = true;
        walking.Play();
    }

    void Update()
    {
        Movement();

        //if the player is in the air or not moving, mute the walking audio
        if(!isGrounded || ((rb.velocity.x == 0f) && (rb.velocity.z == 0f)))
        {
            walking.mute = true;
        } else if (walking.mute == true) //else, if the walking audio is muted, start playing it
        {
            walking.mute = false;
        }
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
            jumping.Play();
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
            landing.Play();
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Jumpable"))
        {
            isGrounded = false;
        }
    }

    public void Recenter()
    {
        if (CameraShift.getScroller() && transform.position.z != 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }

    public bool OnGround()
    {
        return isGrounded;
    }
}
