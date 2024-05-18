using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 3f;
    public LayerMask enemyLayers;
    void Start()
    {
        if(Input.GetKeyDown(KeyCode.E)) 
        {
            Attack();
        }
        
    }

    void Attack()
    {
        animator.SetTrigger("attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit" + enemy.name);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if(attackPoint != null)
        {
            return;
        }
        Gizmos.DrawSphere(attackPoint.position, attackRange);
    }
}
