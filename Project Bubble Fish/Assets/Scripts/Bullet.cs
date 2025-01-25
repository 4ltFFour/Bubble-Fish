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

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        if (hitInfo.tag.Equals("Enemy"))
        {
            Destroy(gameObject);
        }

        if (hitInfo.tag.Equals("Player"))
        {
            
            Destroy(gameObject);
        }

    }

}
