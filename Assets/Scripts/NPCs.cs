using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public float moveSpeed = 2f; // NPC hareket hızı
    public float attackCooldown = 3f; // Saldırı aralığı (saniye)
    public float abilityCooldown = 5f; // Yetenek aralığı (saniye)
    private float nextAttackTime = 0f; // Son saldırı zamanı
    private float nextAbilityTime = 0f; // Son yetenek kullanma zamanı

    private void Update()
    {
        // NPC rastgele hareket et
        MoveRandomly();

        // NPC saldırı yeteneği
        if (Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + attackCooldown;
        }

        // NPC yetenek kullanma
        if (Time.time >= nextAbilityTime)
        {
            UseAbility();
            nextAbilityTime = Time.time + abilityCooldown;
        }
    }

    private void MoveRandomly()
    {
        // Rastgele yön seç
        Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        Vector2 moveAmount = randomDirection.normalized * moveSpeed * Time.deltaTime;
        transform.Translate(moveAmount);
    }

    private void Attack()
    {
        // Burada saldırı kodunu yazabiliriz
        // Örneğin, ateş etme veya silah kullanma işlemleri
        Debug.Log("NPC saldırı yaptı!");
    }

    private void UseAbility()
    {
        // Burada yetenek kodunu yazabilirsiniz
        // Örneğin, ateş topu fırlatma veya özel yetenek kullanma
        Debug.Log("NPC yetenek kullandı!");
    }
}
