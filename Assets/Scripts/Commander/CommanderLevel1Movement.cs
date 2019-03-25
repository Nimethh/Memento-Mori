using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommanderLevel1Movement : StateMachineBehaviour
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
        movingSpot.position = new Vector2(6.5f, Random.Range(minY, maxY));
        rand = Random.Range(0, 4);
        while (prevRand == rand)
        {
            rand = Random.Range(0, 4);
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, movingSpot.position, speed * Time.deltaTime);
        if (Vector2.Distance(animator.transform.position, movingSpot.position) < 0.2f)
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
            else
            {
                animator.SetTrigger("attack4");
            }
        }
    }
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        prevRand = rand;
    }
}
