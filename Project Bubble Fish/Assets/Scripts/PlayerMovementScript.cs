using System;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private bool grounded;
    private Animator anim;
    [SerializeField] private AudioClip popSound;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        anim.SetBool("Run", horizontal != 0);

        Jump();

        Flip();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f) {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            transform.Rotate(0f, 180f, 0f);
            transform.localScale = localScale;
        }
    }

    private float bubbleJumpBoost = 25f;

    public void ApplyBubbleJumpBoost(int boostDirection)
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, boostDirection * bubbleJumpBoost);
        AudioSource.PlayClipAtPoint(popSound, rb.position);
    }

    private void Jump()
    {

        
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
            grounded = false;
            anim.SetBool("grounded", grounded);
            anim.SetTrigger("Jump");
            
        }

        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
            grounded = false;
            anim.SetBool("grounded", grounded);
            anim.SetTrigger("Jump");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //set to ground
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            anim.SetBool("grounded", grounded);
            Debug.Log("grounded");
        }
    }

}
