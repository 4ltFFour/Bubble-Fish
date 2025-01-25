using System;
using UnityEngine;

public class Collision : MonoBehaviour
{

    [SerializeField] private LayerMask groundLayer;
    public Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics2D.OverlapCircle(transform.position, 0.5f, groundLayer))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, Math.Abs(rb.linearVelocity.y));
        }
    }
}
