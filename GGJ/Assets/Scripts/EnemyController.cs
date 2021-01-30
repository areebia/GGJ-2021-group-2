using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    //private variables
    private Rigidbody2D rb;
    private float inputX;

    //public variables
    public float moveSpeed;
    private bool isGrounded;
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

        //make the sprite face the direction we move by flipping it
        if (inputX > 0)
        {
            rend.flipX = false;
        }
        else
        {
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
        else
        {
            anim.SetBool("IsIdle", true);
            anim.SetBool("IsJumping", false);
        }
    }
}
