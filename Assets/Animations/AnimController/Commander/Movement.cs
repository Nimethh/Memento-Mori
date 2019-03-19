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
        //Debug.Log("onStateEnter() " + rand + " " + prevRand);
        movingSpot.position = new Vector2(7.0f, Random.Range(minY, maxY));
        rand = Random.Range(0, 4);
        while(prevRand == rand)
        {
            rand = Random.Range(0, 4);
        }
        //Debug.Log("onStateEnter() " + rand + " " + prevRand);
        Debug.Log("onStateEnter() ");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, movingSpot.position, speed * Time.deltaTime);
        if (Vector2.Distance(animator.transform.position, movingSpot.position) < 0.2f)
        {
        Debug.Log("onStateUpdate() " + rand);
            if (rand == 0)
            {
                animator.SetTrigger("attack1");
                //Debug.Log("Attack1 " + rand);
            }
            else if (rand == 1)
            {
                animator.SetTrigger("attack2");
                //Debug.Log("Attack2 " + rand);
            }
            else if (rand == 2)
            {
                animator.SetTrigger("attack3");
                //Debug.Log("Attack3 " + rand);
            }
            else
            {
                animator.SetTrigger("attack4");
                //Debug.Log("Attack 4 " + rand);
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        prevRand = rand;
    }

}
