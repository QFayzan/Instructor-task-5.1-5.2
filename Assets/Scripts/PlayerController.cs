using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isDead = false;
    public Rigidbody rb;
    public Transform tf;
    public Animator animator;
    public float horizontalInput;
    public float verticalInput;
    public float moveSpeed;
    public int health;
    public float xRange;
    public float zRange;
    public static float jumpTimer = 0;
    public float healthTimer = 0;
    public float healthTimerDisplay = 10;
    public Vector3 KeyboadMovementDirection;
    public float rotationSpeed;
    public bool isJumping;
    public bool isGrounded; //here is grounded means white tile since player can walk on it for animations
    public bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tf = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        moveSpeed = 3.0f;
        rotationSpeed = 720;
        health = 3;
        canMove = true;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!isDead && canMove)
        {
            BasicMovement();
            CanJump();
        }
        
    }
    public void CanJump()
    {
        if (!isDead)
        {
            jumpTimer += Time.deltaTime;
            if (jumpTimer > 1.5f && Input.GetKeyDown(KeyCode.Space))
            {
                Jump();

            }
        }
    }
    public void Jump()
    {
        rb.AddForce(Vector3.up * 6, ForceMode.Impulse);
        jumpTimer = 0;
    }
    public void BasicMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        // transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * moveSpeed);
        //verticalInput = Input.GetAxis("Vertical");
        // transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * moveSpeed);
        KeyboadMovementDirection = new Vector3(horizontalInput, 0, 0);
        KeyboadMovementDirection.Normalize();
        transform.Translate(KeyboadMovementDirection * moveSpeed * Time.deltaTime, Space.World);
    }
}
