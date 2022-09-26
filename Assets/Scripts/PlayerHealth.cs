using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 50f;
    public int maxHealth = 100;
    public HealthBar healthBar;

    void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


    public void TakeDamage (float amount)

    {
        health -= amount;

        healthBar.SetHealth(health);

        if (health <= 0f)
        {
            Die();
        }

    }

    void Die ()

    {
        gameObject.SetActive(false);
    }
}
