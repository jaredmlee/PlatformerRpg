using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Anim : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rb;
    public float speed = 0.1f;
    public float attackRange = 1f;
    Swordsman swordsman;
    public float attackSpeed = 0.7f;

    float nextAttackTime = 0f;



    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        swordsman = animator.GetComponent<Swordsman>();
        attackRange = swordsman.GetComponent<Swordsman>().attackRange;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        swordsman.lookAtPlayer();

        if (Vector2.Distance(player.position, rb.position) <= attackRange && (Time.time >= nextAttackTime))
        {
            if (player.GetComponent<Player_script>().isAlive)
            {
                animator.SetTrigger("Attack");
                nextAttackTime = Time.time + 1f / attackSpeed;
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
}
