using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.02f;
    [SerializeField] float jumpForce = 2.0f;

    public Vector3 jump;
    public bool isGrounded;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void Update()
    {
        CheckPosition();

        float xDir = Input.GetAxis("Horizontal");
        float zDir = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        Vector3 moveDir = new Vector3(xDir, 0.0f, zDir);
        transform.position += moveDir * moveSpeed;
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void CheckPosition()
    {
        float horizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x + horizontal, -8, 8);
        pos.z = Mathf.Clamp(pos.z + vertical, -8, 8);
        transform.position = pos;
    }
}
