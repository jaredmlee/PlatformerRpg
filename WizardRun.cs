using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardRun : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rb;
    public float speed = 1f;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance <= 2)
        {
            Vector3 target;
            if (player.position.x > animator.transform.position.x)
            {
                target = new Vector2(animator.transform.position.x - 2, animator.transform.position.y);
            }
            else
            {
                target = new Vector2(animator.transform.position.x + 2, animator.transform.position.y);
            }
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, target, speed * Time.deltaTime);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
