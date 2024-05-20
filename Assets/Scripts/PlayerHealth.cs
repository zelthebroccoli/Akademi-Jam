using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 500;
    public int currenthealth;
    private int direction = 1;
    public HealthBar healthBar;
    public Animator anim;
    // Start is called before the first frame update
    public void Start()
    {
        currenthealth = maxHealth;
        anim = GetComponent<Animator>();
        healthBar.SetMaxHealth(maxHealth);
    }

    public void RecievedDamage(int damage)
    {
        currenthealth -= damage;
        healthBar.SetHealth(currenthealth);

        if (currenthealth <= 0)
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
