using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    public Rigidbody2D rigid;
    public SpriteRenderer spriteRenderer;
    public Transform groundCheck;

    public float checkRadius;
    public float speed;
    public float jumpPower;

    bool isFacingRight = true;
    bool isGround;

    public LayerMask whatIsGround;
    void Update()
    {
        Debug.Log(isGround);
        Move();
        Jump();

        isGround = CheckOnGround();



        void Move()
        {
            float inputHorizon = Input.GetAxis("Horizontal");
            float inputVertical = Input.GetAxis("Vertical");

            rigid.velocity = new Vector2(inputHorizon * speed, rigid.velocity.y);

            if (isFacingRight && inputHorizon < 0)
            {

                Flip();
            }
            else if (!isFacingRight && inputHorizon > 0)
            {
                Flip();
            }
        }
        void Flip()
        {
            isFacingRight = !isFacingRight;
            spriteRenderer.flipX = !isFacingRight;
        }
        void Jump()
        {
            if (Input.GetButtonDown("Jump") && isGround)
            {
                rigid.velocity = new Vector2(rigid.velocity.x, jumpPower/* * (speed * 0.1f)*/);
                
            }
            
        }

        }
        bool CheckOnGround()
        {
        return Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        }
} 
