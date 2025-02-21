using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 3;
    public int currenthealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currenthealth = maxHealth;
    }
    void TakeDamage(int amount)
    {
        currenthealth -= amount;

        if(currenthealth <= 0)
        {
            //gameover
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
