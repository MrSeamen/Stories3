using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.02f;
    [SerializeField] float jumpForce = 2.0f;

    public Animator animator;
    public SpriteRenderer sprite;
    public TrackTransition trackTransition;
    public Vector3 _direction;
    private Vector3 jump;
    public bool isGrounded;
    Rigidbody rb;

    public GameObject door1;
    public GameObject door2;
    public GameObject door3;

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
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 _inputVector = context.ReadValue<Vector2>();
        if(CameraShift.getScroller())
        {
            _direction = new Vector3(_inputVector.x, 0, 0);
            if (_direction == Vector3.zero && !trackTransition.IsTransitioning())
            {
                animator.SetBool("IsWalking", false);
            }
            else
            {
                animator.SetBool("IsWalking", true);
                sprite.flipX = (_inputVector.x < 0);
            }
        } else
        {
            if (context.performed && _inputVector.y != 0)
            {
                trackTransition.AttemptTransition(_inputVector.y > 0, animator);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Jumpable"))
        {
            isGrounded = true;
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
