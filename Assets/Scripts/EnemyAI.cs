using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    private Animator anim;
    private PlayerHealth playerHealth;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        //Attack only when player in sight?
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("attack");
            }
        }
    }
    
    public bool PlayerInSight()
    {
        Vector2 boxCenter = (Vector2)boxCollider.bounds.center + (Vector2.right * range * transform.localScale.x * colliderDistance);
        Vector2 boxSize = new Vector2(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y);
        Collider2D hit = Physics2D.OverlapBox(boxCenter, boxSize, 0, playerLayer);

        Debug.Log("Box Center: " + boxCenter);
        Debug.Log("Box Size: " + boxSize);

        if (hit != null)
        {
            playerHealth = hit.GetComponent<PlayerHealth>();
            Debug.Log("Player detected");
        }
        else
        {
            Debug.Log("Player not detected");
        }

        return hit != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector2 boxCenter = (Vector2)boxCollider.bounds.center + (Vector2.right * range * transform.localScale.x * colliderDistance);
        Vector2 boxSize = new Vector2(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y);
        Gizmos.DrawWireCube(boxCenter, boxSize);
    }
    public void ApplyDamage()
    {
        if (playerHealth != null)
        {
            Debug.Log("Applying damage to player");
            playerHealth.TakeDamage(damage, transform.position.x > playerHealth.transform.position.x ? 1 : -1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
            if (player != null)
            {
                int knockbackDirection = transform.position.x > player.transform.position.x ? 1 : -1;
                player.TakeDamage(damage, knockbackDirection);
            }
        }
    }
}

