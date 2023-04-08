using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    
    public float jumpVelocity;
    public float fallMultiplier = 2.5f;
    public float lowMutiplier = 2f;

    private bool isGround;
    private BoxCollider2D myFeet;
    Rigidbody2D rb;

    void Awake()
    {
        myFeet = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    void checkGrounded()
    {
        isGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"));
        Debug.Log(isGround);
    }

    // Update is called once per frame
    void Update()
    {
        checkGrounded();
        if (Input.GetButtonDown("Jump") && isGround)
        {
            GetComponent<Rigidbody2D> ().velocity = jumpVelocity * Vector2.up;
        }
        if(rb.velocity.y < 0f)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }else if(rb.velocity.y > 0f && !Input.GetButton("Jump")){
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowMutiplier - 1) * Time.deltaTime;
        }
        checkGrounded();
    }
}
