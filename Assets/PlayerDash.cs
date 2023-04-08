using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashSpeed;
    public float dashTime;
    public float dashCooldownTime;
    private float dashTimer;
    private bool isDashing;
    private float direction;
    

    Rigidbody2D rb;
    private TrailRenderer tr;
    // Update is called once per frame

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        Dash();
    }

    private void Dash()
    {
        if(Input.GetAxisRaw("Horizental") != 0)
        {
            direction = Input.GetAxisRaw("Horizental");
        }

        if (Input.GetKeyDown(KeyCode.LeftShift)){
            isDashing = true;
            dashCooldownTime = Time.time + dashTime;
            rb.velocity = new Vector2(direction * dashSpeed, 0);
            rb.gravityScale = 0f;
        }
        if(Time.time > dashCooldownTime)
        {
            isDashing=false;
            rb.gravityScale = Physics2D.gravity.y;
        }
    }
}
