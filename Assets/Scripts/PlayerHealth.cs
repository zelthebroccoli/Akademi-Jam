using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance; // Singleton instance

    public int maxHealth = 500;
    public int currentHealth;
    private int direction = 1;
    public HealthBar healthBar;
    public Animator anim;

    private void Awake()
    {
        // Singleton pattern implementation
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep the player object between scene loads
        }
        else
        {
            Destroy(gameObject); // If another instance exists, destroy this one
        }
    }

    // Start is called before the first frame update
    public void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        healthBar.SetMaxHealth(maxHealth);
    }

    public void RecievedDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            Hurt();
        }
    }

    public void Hurt()
    {
        anim.SetBool("hurt", true);
        float knockbackDistance = 1f; // Adjust this value to control knockback distance
        Vector3 knockbackDirection = new Vector3(direction == 1 ? -knockbackDistance : knockbackDistance, 0.5f, 0); // Adjust the Y component for upward knockback
        transform.position += knockbackDirection;
    }

    public void Die()
    {
        anim.SetBool("die", true);
        Destroy(gameObject);
    }
}
