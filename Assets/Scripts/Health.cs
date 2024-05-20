using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int enemyHealth = 40;
    private int direction = 0;
    public int bossHealth = 300;

    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    public void TakeDamage(int damage)
    {
        if (gameObject.CompareTag("Boss"))
        {
            bossHealth -= damage;
            if (bossHealth <= 0)
            {
                Die();
            }
            else
            {
                Hurt();
            }
        }

        else if (gameObject.CompareTag("Enemy"))
        {
            enemyHealth -= damage;
            if (enemyHealth <= 0)
            {
                Die();
            }
            else
            {
                Hurt();
            }
        }

       

    }
    public void Hurt()
    {
        anim.SetTrigger("hurt");

        // Horizontal knockback
        float knockbackDistanceX = 0f; // Adjust this value to control horizontal knockback distance
        Vector3 knockbackDirectionX = new Vector3(direction == 0 ? -knockbackDistanceX : knockbackDistanceX, 0, 0);
        transform.position += knockbackDirectionX;

        // Vertical knockback
        float knockbackDistanceY = 0f; // Adjust this value to control vertical knockback distance
        Vector3 knockbackDirectionY = new Vector3(0, knockbackDistanceY, 0);
        transform.position += knockbackDirectionY;
    }

    public void Die()
    {
        anim.SetTrigger("die");
        if (gameObject.CompareTag("Boss"))
        {
            Destroy(gameObject); // Destroy the current boss GameObject
        }
        else if (gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject); // Destroy the current enemy GameObject
        }
    }
}

