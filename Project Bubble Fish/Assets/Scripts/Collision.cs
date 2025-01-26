using System;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public float bounceAmount = 5;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform floorCheck;
    [SerializeField] private Transform ceilingCheck;
    [SerializeField] private Transform leftWallCheck;
    [SerializeField] private Transform rightWallCheck;
    public Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // // floor check
        // if(Physics2D.OverlapCircle(floorCheck.position, 0.1f, groundLayer))
        // {
        //     rb.linearVelocity = new Vector2(rb.linearVelocity.x, bounceAmount);
        //     print("floor collision");
        // }

        // // ceiling check
        // if(Physics2D.OverlapCircle(ceilingCheck.position, 0.1f, groundLayer))
        // {
        //     rb.linearVelocity = new Vector2(rb.linearVelocity.x, bounceAmount * -1);
        //     print("left wall collision");
        // }

        // // left wall check
        // if(Physics2D.OverlapCircle(leftWallCheck.position, 0.1f, groundLayer))
        // {
        //     rb.linearVelocity = new Vector2(bounceAmount, rb.linearVelocity.y);
        //     print("left wall collision");
        // }

        // // right wall check
        // if(Physics2D.OverlapCircle(rightWallCheck.position, 0.1f, groundLayer))
        // {
        //     rb.linearVelocity = new Vector2(bounceAmount * -1, rb.linearVelocity.y);
        //     print("left wall collision");
        // }
    }
}
