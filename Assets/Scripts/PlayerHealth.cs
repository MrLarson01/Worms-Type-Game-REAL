using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    public static event Action OnPlayerDeath;
    public float health = 50f;
    public int maxHealth = 100;
    public HealthBar healthBar;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
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
            OnPlayerDeath?.Invoke();
        }

    }

    void Die ()

    {
        Cursor.lockState = CursorLockMode.None;        
        gameObject.SetActive(false);
    }
}
