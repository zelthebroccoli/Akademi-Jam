using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossDamage : MonoBehaviour
{
    // Public variables for easy configuration in the Unity Inspector
    public int maxHealth = 100; // Maximum health of the boss
    public int currentHealth; // Current health of the boss

    // Reference to an animator to play death animations, if any
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the boss's health
        currentHealth = maxHealth;
    }

    // This function will be called to inflict damage on the boss
    public void TakeDamage(int damage)
    {
        // Reduce the current health by the damage amount
        currentHealth -= damage;

        // If there's an animator, optionally play a hurt animation
        if (animator != null)
        {
            animator.SetTrigger("damage");
        }

        // Check if the boss's health has dropped to zero or below
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // This function handles the boss's death
    void Die()
    {
        Debug.Log("Boss Defeated!");

        // If there's an animator, play the death animation
      

        // Disable the boss's collider so it no longer interacts with the player
        GetComponent<Collider2D>().enabled = false;

        // Disable this script to prevent further damage processing
        this.enabled = false;

        // Optionally destroy the boss game object after a delay
        // Destroy(gameObject, 2f);
    }
}

