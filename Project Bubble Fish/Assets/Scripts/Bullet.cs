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

        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.BecomeBubbled(100);
        }

        if (hitInfo.tag.Equals("Enemy") || hitInfo.tag.Equals("Player"))
        {

            Destroy(gameObject);
        }

    }

}
