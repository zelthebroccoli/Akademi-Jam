using UnityEngine;

public class idleBehavior : StateMachineBehaviour
{
    public float timer;
    public float minTime;
    public float maxTime;
    public float attackRange = 3f; 
    public Transform playerPos;
    public float speed;
    Rigidbody2D boss;
    

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = Random.Range(minTime, maxTime);
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        boss= GameObject.FindGameObjectWithTag ("Boss").GetComponent <Rigidbody2D>();
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
        {
            animator.SetTrigger("walk");
        }
        else
        {
            timer -= Time.deltaTime;
        }
        Vector2 target = new Vector2(playerPos.position.x, playerPos.position.y);
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, target, speed * Time.deltaTime);
        animator.GetComponent<BossAI>().PlayerInSight();
        
        if (Vector2.Distance(playerPos.position, boss.position )<= attackRange)
        {
            animator.SetTrigger("attack");
        } 
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("attack");
    }
}

