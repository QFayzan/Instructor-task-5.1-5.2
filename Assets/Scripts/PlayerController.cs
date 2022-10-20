using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI healthDisplay;
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
    public static int score = 0;
    public TextMeshProUGUI scoreDisplay;
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
        score = 0;

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
    public void Death()
    {
        isDead = true;
        canMove=false;
        Debug.Log("Game Over");
    }
    private void Update()
    {
        healthDisplay.text = "Current HP is :" + health.ToString();
        scoreDisplay.text = "Score :" + score.ToString();
        if (health <1 )
        {
            Death();
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health--;
        }
    }
}
