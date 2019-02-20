using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchState : StateMachineBehaviour
{
    public float timer;
    private float timerCountDown;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timerCountDown = timer;
    }
    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetTrigger("moving");
        
    }
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
