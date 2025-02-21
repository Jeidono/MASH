using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    public Image heart1; // Assign these in the Inspector
    public Image heart2;
    public Image heart3;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHearts();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        UpdateHearts();

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void UpdateHearts()
    {
        heart1.enabled = currentHealth >= 1;
        heart2.enabled = currentHealth >= 2;
        heart3.enabled = currentHealth >= 3;
    }
}
