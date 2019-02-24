using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectAttack : StateMachineBehaviour
{
    private int rand;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rand = Random.Range(0, 2);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (rand == 0)
        {
            animator.SetTrigger("Attack2");
        }
        else
            animator.SetTrigger("Attack3");
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
