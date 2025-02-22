using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    public Image heart1; 
    public Image heart2;
    public Image heart3;
    public GameManager gameManager;
    
    private bool isDead;


    void Start()
    {
        currentHealth = maxHealth;
        UpdateHearts();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        UpdateHearts();

        if (currentHealth <= 0 && !isDead)
        {
            Destroy(gameObject);
            gameManager.gameOver();
            Debug.Log("dead");
        }
    }

    void UpdateHearts()
    {
        heart1.enabled = currentHealth >= 1;
        heart2.enabled = currentHealth >= 2;
        heart3.enabled = currentHealth >= 3;
    }
}
