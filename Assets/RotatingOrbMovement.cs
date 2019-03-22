using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingOrbMovement : StateMachineBehaviour
{
    public float speed;
    public Transform mP;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, mP.transform.position, speed * Time.deltaTime);
    }
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
    
}
