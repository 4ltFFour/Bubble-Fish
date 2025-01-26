using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private int direction = -1;
    public float speed = 5;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float damage;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask enemies;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapCircle(wallCheck.position, 0.1f, groundLayer) || Physics2D.OverlapCircle(wallCheck.position, 0.1f, enemies))
        {
            direction *= -1;
            transform.Rotate(0f, 180f, 0f);
        }
    }
}
