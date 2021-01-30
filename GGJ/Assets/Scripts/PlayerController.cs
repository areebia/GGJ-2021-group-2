using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

   //private variables
    private Rigidbody2D rb;
    private float inputX;

    //public variables
    public float moveSpeed, jumpspeed;
    private bool isGrounded, canJump, jumpAnim;
    public Animator anim;
    public SpriteRenderer rend;
     
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            isGrounded = false;
        }
    }
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");

        //check if we are grounded to jump in fixedupdate
        if (isGrounded)
        {
            jumpAnim = true;

            if (Input.GetButton("Jump")) {
                canJump = true;
            }
            
        }
        else {
            jumpAnim = false;
            canJump = false;
        }

        //check if we move and if so, move in the wasd direction
        if (inputX != 0 && jumpAnim == true)
        {
            anim.SetBool("IsJumping", false);
            anim.SetBool("IsIdle", false);
            anim.SetBool("IsRunning", true);
            rb.velocity = new Vector2(inputX * moveSpeed, rb.velocity.y);
        }
        else if (inputX != 0 && jumpAnim == false)
        {
            anim.SetBool("IsJumping", true);
            anim.SetBool("IsRunning", false);
            anim.SetBool("IsIdle", false);
            rb.velocity = new Vector2(inputX * moveSpeed, rb.velocity.y);
        }
        else {
            anim.SetBool("IsIdle", true);
            anim.SetBool("IsRunning", false);
        }

        //make the sprite face the direction we move by flipping it
        if (inputX > 0)
        {
            rend.flipX = false;
        }
        else {
            rend.flipX = true;
        }
    }
    private void FixedUpdate()
    {
        //animations and jumping
        if (canJump == true)
        {
            anim.SetBool("IsJumping", true);
            rb.AddForce(Vector2.up * jumpspeed);
        }
        else {
            anim.SetBool("IsIdle", true);
            anim.SetBool("IsJumping", false);
        }
    }
}

