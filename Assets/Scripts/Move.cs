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
    private Vector3 _direction;
    private Vector3 jump;
    private bool isGrounded;
    Rigidbody rb;

    public AudioSource audioSource;
    public AudioClip walking;
    public AudioClip jumping;
    public AudioClip landing;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        _direction = new Vector3(0.0f, 0.0f, 0.0f);
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

            if (_direction == Vector3.zero || !isGrounded)
            {
                animator.SetBool("IsWalking", false);
                if (audioSource.clip == walking)
                {
                    audioSource.Pause();
                }
            }
            else
            {
                animator.SetBool("IsWalking", true);
                if (audioSource.clip != walking)
                {
                    audioSource.loop = true;
                    audioSource.clip = walking;
                    audioSource.Play();
                }
            }
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            isGrounded = false;
            Vector3 movement = jump * jumpForce;
            rb.velocity = movement;

            audioSource.Stop();
            audioSource.loop = false;
            audioSource.clip = jumping;
            audioSource.Play();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 _inputVector = context.ReadValue<Vector2>();
        if(CameraShift.getScroller())
        {
            _direction = new Vector3(_inputVector.x, 0, 0);
            if (_direction != Vector3.zero || trackTransition.IsTransitioning())
            {
                sprite.flipX = (_inputVector.x < 0);
            }
        } else
        {
            if (context.performed && _inputVector.y != 0)
            {
                trackTransition.AttemptTransition(_inputVector.y > 0, animator, audioSource, walking);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Jumpable"))
        {
            audioSource.Stop();
            audioSource.loop = false;
            audioSource.clip = landing;
            audioSource.Play();

            isGrounded = true;
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

    public bool isMoving()
    {
        if(_direction != Vector3.zero)
        {
            return true;
        } else
        {
            return false;
        }
    }

    public float DirectionX()
    {
        return _direction.x;
    }

}
