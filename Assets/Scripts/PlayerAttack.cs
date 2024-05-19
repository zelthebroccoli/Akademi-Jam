using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack=0f;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;
    public int bossDamage = 20;
    public int enemyDamage = 10;
    public void Update()
    {
        if (timeBtwAttack <= 0)
        {
            if(Input.GetKeyDown(KeyCode.E)) 
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for(int i = 0; i < enemiesToDamage.Length; i++)
                {
                    Health bossHealth = enemiesToDamage[i].GetComponent<Health>();
                    if(bossHealth != null )
                    {
                        bossHealth.TakeDamage(damage);
                    }

                    Health enemyHealth = enemiesToDamage[i].GetComponent<Health>();
                    if (enemyHealth!=null)
                    {
                        enemyHealth.TakeDamage(damage);
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
