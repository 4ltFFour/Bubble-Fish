using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 10f;
    public Rigidbody2D rb;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.BecomeBubbled(100);
            Destroy(gameObject);
        }

        PlayerMovementScript player = hitInfo.GetComponent<PlayerMovementScript>();
        if (player != null)
        {
            Vector2 collisionDirection = transform.position - hitInfo.transform.position;
            Destroy(gameObject);
            if (collisionDirection.y < 0) // Player is above the bubble
            {
                player.ApplyBubbleJumpBoost(1);
                Destroy(gameObject);
            }
            else if (collisionDirection.y > 0) // Player is below the bubble
            {
                player.ApplyBubbleJumpBoost(-1);
                Destroy(gameObject);
            }
        }
    }


}
