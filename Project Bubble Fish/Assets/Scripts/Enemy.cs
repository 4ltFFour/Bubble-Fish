using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 1;

    public GameObject bubbledEnemy;
    public Transform enemy;

    public void BecomeBubbled (int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die ()
    {
        Instantiate(bubbledEnemy, enemy.position, enemy.rotation);
        Destroy(gameObject);

    }

}
