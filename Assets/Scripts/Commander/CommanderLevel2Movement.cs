using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommanderLevel2Movement : StateMachineBehaviour
{
    public Transform movingSpot;

    public float minY;
    public float maxY;
    public float speed;

    [SerializeField]
    private int rand;
    [SerializeField]
    private int prevRand;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rand = Random.Range(0, 5);
        while (prevRand == rand)
        {
            rand = Random.Range(0, 5);
        }
    }
    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (rand == 0)
        {
            animator.SetTrigger("attack1");
        }
        else if (rand == 1)
        {
            animator.SetTrigger("attack2");
        }
        else if (rand == 2)
        {
            animator.SetTrigger("attack3");
        }
        else if (rand == 3)
        {
            animator.SetTrigger("attack4");
        }
        else if (rand == 4)
        {
            animator.SetTrigger("attack5");
        }
    }
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        prevRand = rand;
    }
}
