using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    private float startTimeBtwAttack=0f;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    private float attackRange=4f;
    private int bossDamage = 20;
    private int enemyDamage = 10;
    public void Update()
    {
        if (timeBtwAttack <= 0)
        {
            if(Input.GetKeyDown(KeyCode.E)) 
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for(int i = 0; i < enemiesToDamage.Length; i++)
                {
                    Health enemyHealth = enemiesToDamage[i].GetComponent<Health>();
                    if (enemyHealth != null)
                    {
                        // Check if the enemy is a boss or a regular enemy
                        if (enemiesToDamage[i].CompareTag("Boss"))
                        {
                            enemyHealth.TakeDamage(bossDamage);
                        }
                        else
                        {
                            enemyHealth.TakeDamage(enemyDamage);
                        }
                    }

                }
            }
            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPos.position,attackRange);
    }
}
