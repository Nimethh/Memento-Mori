using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : StateMachineBehaviour
{
    public Transform movingSpot;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float speed;

    [SerializeField]
    private int rand;
    [SerializeField]
    private int prevRand;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        movingSpot.position = new Vector2(7.0f, Random.Range(minY, maxY));
        if (animator.gameObject.name == "CommanderLevel1")
        {
            rand = Random.Range(0, 4);
            while (prevRand == rand)
            {
                rand = Random.Range(0, 4);
            }
        }
        else if (animator.gameObject.name == "CommanderLevel2")
        {
            rand = Random.Range(0, 5);
            while (prevRand == rand)
            {
                rand = Random.Range(0, 5);
            }
        }

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.gameObject.name == "CommanderLevel1")
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
        else if (animator.gameObject.name == "CommanderLevel2")
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
            else if(rand == 3)
            {
                animator.SetTrigger("attack4");
            }
            else if(rand == 4)
            {
                animator.SetTrigger("attack5");
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        prevRand = rand;
    }

}
