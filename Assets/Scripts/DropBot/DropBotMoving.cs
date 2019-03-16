using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBotMoving : StateMachineBehaviour
{
    public Transform movingSpot;
    public float speed;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(animator.transform.position, movingSpot.position) > 0.2f)
        {
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, movingSpot.position, speed * Time.deltaTime);
        }

        if (Vector2.Distance(animator.transform.position, movingSpot.position) < 0.2f)
        {
            animator.SetTrigger("Drop");
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
