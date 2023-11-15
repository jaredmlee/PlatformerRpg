using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard_Anim : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rb;
    public float speed = 0.1f;
    public float attackRange = 1f;
    FireWizard fireWizard;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        fireWizard = animator.GetComponent<FireWizard>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        fireWizard.lookAtPlayer();


        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            if (player.GetComponent<Player_script>().isAlive)
            {
                animator.SetTrigger("attack");
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("attack");
    }
}

