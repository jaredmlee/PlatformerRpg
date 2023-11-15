using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm_anim : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rb;
    public float speed = 0.5f;
    public float attackRange = 0.5f;
    Worm worm;

    private float nextAttackTime = 0f;
    public float AttackCoolDown = 1f;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        worm = animator.GetComponent<Worm>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        worm.lookAtPlayer();
        float distance = Vector3.Distance(player.position, rb.transform.position);
        if (distance <= 3)
        {
            Vector3 target = new Vector2(player.position.x, animator.transform.position.y);
            if (animator.transform.position == target)
            {
                return;
            }
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, target, speed * Time.deltaTime);
        }


        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            if (player.GetComponent<Player_script>().isAlive)
            {
                if (Time.time >= nextAttackTime)
                {
                    animator.SetTrigger("Attack");
                    nextAttackTime = Time.time + 1f / AttackCoolDown;
                }
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
}
