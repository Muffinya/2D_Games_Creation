using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Movement : MonoBehaviour
{
    //movement
    public float speed;
    float moveInput;
    Rigidbody2D rb;
    public float flipX;
    public bool flipped;

    //jumping
    public float jumpForce;
    public int jumpsAmount;
    int gJumps = 1;
    int aJumpsLeft;
    public Transform GroundCheck;
    public LayerMask GroundLayer;
    bool isGrounded;

    
    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        flipX = transform.localScale.x;
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        //handles movement
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        //handles character sprite orientation
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(flipX, transform.localScale.y, transform.localScale.z);
            flipped = false;
        }
        if (moveInput < 0)
        {
            transform.localScale = new Vector3((-1) * flipX, transform.localScale.y, transform.localScale.z);
            flipped = true;
        }

        CheckIfGrounded();

        //handles ground jumping
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            if (gJumps > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                gJumps--;
            }
        }

        //handles airiel jumping
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0) && !isGrounded)
        {
            if (aJumpsLeft > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                aJumpsLeft--;
            }
        }

    }
    public void CheckIfGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheck.GetComponent<CircleCollider2D>().radius, GroundLayer);
        ResetJumps();
    }

    public void ResetJumps()
    {
        if (isGrounded)
        {
            gJumps = 1;
        }
        if (isGrounded)
        {
            aJumpsLeft = jumpsAmount;
        }

    }
}
