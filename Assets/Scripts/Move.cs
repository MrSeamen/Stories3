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
    Rigidbody rb;
    private bool isGrounded;
    private bool isJumping = false;
    private bool isWalking = false;
    private bool isFalling = false;
    private bool isPushing = false;
    private bool isPulling = false;
    private bool movementLocked = false;

    public AudioSource audioSource;
    public AudioClip walking;
    public AudioClip jumping;
    public AudioClip landing;
    public float fallingThreshold;
    //private Coroutine fallTimerInstance;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        _direction = new Vector3(0.0f, 0.0f, 0.0f);
        movementLocked = false;
        TogglePinocchio(false);
    }

    void Update()
    {
        if(rb.velocity.y < fallingThreshold)
        {
            isFalling = true;
            isGrounded = false;
            animator.SetBool("IsFalling", true);
        } else
        {
            isFalling = false;
            animator.SetBool("IsFalling", false);
        }

        if(!movementLocked)
        {
            Movement();
        }
    }

    public void TogglePinocchio(bool hasPinocchio)
    {
        animator.SetBool("HasPinocchio", hasPinocchio);
    }

    public void TogglePush(bool push)
    {
        if(isPushing != push)
        {
            isPushing = push;
            animator.SetBool("IsPushing", push);
            Debug.Log(push);
            if (push)
            {
                TogglePull(false);
            }
        }
    }

    public void TogglePull(bool pull)
    {
        if (isPulling != pull)
        {
            isPulling = pull;
            animator.SetBool("IsPulling", pull);
            if (pull)
            {
                TogglePush(false);
            }
        }
    }

    public void StopMovement(InputAction.CallbackContext context)
    {
        StopMovement();
    }

    public void StopMovement()
    {
        if (CameraShift.getScroller())
        {
            _direction = Vector3.zero;
            animator.SetBool("IsWalking", false);
            isWalking = false;
            rb.velocity = Vector3.zero;
            audioSource.Pause();
        }
    }

    public void Movement()
    {
        if(CameraShift.getScroller())
        {
            Vector3 movement = new Vector3(_direction.x * moveSpeed, rb.velocity.y, 0);
            rb.velocity = movement;

            if (_direction == Vector3.zero)
            {
                if (isWalking)
                {
                    animator.SetBool("IsWalking", false);
                    isWalking = false;
                    audioSource.Pause();
                }
            }
            else if (!isGrounded) //these need to be separate for jump sound effect to occur while moving
            {
                if (isWalking)
                {
                    animator.SetBool("IsWalking", false);
                    isWalking = false;
                }
            }
            else
            {
                if (!isWalking)
                {
                    animator.SetBool("IsWalking", true);
                    isWalking = true;
                    if (audioSource.clip != walking)
                    {
                        audioSource.loop = true;
                        audioSource.clip = walking;
                    }
                    audioSource.Play();
                }
                if (audioSource.clip != walking)
                {
                    audioSource.loop = true;
                    audioSource.clip = walking;
                    audioSource.Play();
                }
            }
        } else
        {
            Vector3 movement = new Vector3(0, 0, rb.velocity.z);
            rb.velocity = movement;
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded && !movementLocked && CameraShift.getScroller())
        {
            isJumping = true;
            animator.SetBool("IsJumping", true);
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
        if (CameraShift.getScroller())
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
        if (collision.contacts.Length > 0)
        {
            ContactPoint contact = collision.contacts[0];
            if (Vector3.Dot(contact.normal, Vector3.up) > 0.5)
            {
                //collision was from below

                audioSource.Stop();
                audioSource.loop = false;
                audioSource.clip = landing;
                audioSource.Play();

                isGrounded = true;
                isJumping = false;
                animator.SetBool("IsJumping", false);
            }
        }
    }

    public void LockMovement(bool shouldLock)
    {
        StopMovement();
        movementLocked = shouldLock;
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

    public void SetMovementZero()
    {
        _direction = Vector3.zero;
    }

}
