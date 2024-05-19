using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idletwoBehavior : StateMachineBehaviour
{
    public float timer;
    public float minTime;
    public float maxTime;
    public float attackRange = 3f;
    public Transform playerPos;
    public float speed;
    Rigidbody2D enemy;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = Random.Range(minTime, maxTime);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerPos = player.transform;
        }
        else
        {
            Debug.LogError("Player not found! Make sure the player GameObject is tagged correctly.");
        }

        GameObject enemyObject = GameObject.FindGameObjectWithTag("Enemy");
        if (enemyObject != null)
        {
            enemy = enemyObject.GetComponent<Rigidbody2D>();
        }
        else
        {
            Debug.LogError("Enemy not found! Make sure the enemy GameObject is tagged correctly.");
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
        {
            animator.SetTrigger("run");
        }
        else
        {
            timer -= Time.deltaTime;
        }

        if (playerPos != null && enemy != null)
        {
            Vector2 target = new Vector2(playerPos.position.x, playerPos.position.y);
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, target, speed * Time.deltaTime);

            if (Vector2.Distance(playerPos.position, enemy.position) <= attackRange)
            {
                animator.SetTrigger("attack");
            }
        }
        else
        {
            Debug.LogError("playerPos or enemy is null!");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("attack");
    }
}