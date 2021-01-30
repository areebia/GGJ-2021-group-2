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
    private bool isGrounded;
    public Animator anim;
     
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
       
        if (inputX != 0)
        {
            rb.velocity = new Vector2( inputX * moveSpeed, rb.velocity.y);
        }

        if (isGrounded && Input.GetButton("Jump"))
        {
            rb.AddForce(Vector2.up * jumpspeed);
        }
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor") {
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
}
