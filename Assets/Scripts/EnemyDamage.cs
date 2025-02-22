using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public Health health;
    public int damageAmount = 1; // Damage amount for this enemy (can be customized per enemy in the Unity Editor)

    void Start()
    {
        // Initialization if needed
    }

    void Update()
    {
        // Update logic if needed
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            health.TakeDamage(damageAmount); // Apply custom damage to the player
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            health.TakeDamage(damageAmount); // Apply custom damage to the player
        }
    }
}
