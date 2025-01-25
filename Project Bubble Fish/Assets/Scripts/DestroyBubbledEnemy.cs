using UnityEngine;

public class DestroyBubbledEnemy : MonoBehaviour
{
    public Rigidbody2D rb;

    private float bounce = 30f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
            Destroy(gameObject);
        }
    }
}
