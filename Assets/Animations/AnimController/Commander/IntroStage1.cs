using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroStage1 : StateMachineBehaviour
{
    public Transform introSpot;
    public float speed;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, introSpot.position, speed * Time.deltaTime);
        if (Vector2.Distance(animator.transform.position, introSpot.transform.position) < 0.2f)
        {
            animator.SetTrigger("moving");
        }
    }
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
    
}
