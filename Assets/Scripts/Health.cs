using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int enemyHealth = 40;
    private int direction = 1;
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
        float knockbackDistance = 1f; // Adjust this value to control knockback distance
        Vector3 knockbackDirection = new Vector3(direction == 1 ? -knockbackDistance : knockbackDistance, 0.5f, 0); // Adjust the Y component for upward knockback

        transform.position += knockbackDirection;

    }

    public void Die()
    {
        anim.SetTrigger("die");
        if(bossHealth <=0)
        {
            Destroy(GameObject.FindGameObjectWithTag ("Boss"));
        }
        else if (enemyHealth <=0)
        {
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }
}

