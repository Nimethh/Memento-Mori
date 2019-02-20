﻿using System.Collections;
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

    private int rand;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        movingSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        rand = Random.Range(0, 3);
    }
    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, movingSpot.position, speed * Time.deltaTime);
       

        if (Vector2.Distance(animator.transform.position, movingSpot.position) < 0.2f)
        {
            if (rand == 0)
            {
                animator.SetTrigger("attack2");
            }
            else if (rand == 1)
            {
                animator.SetTrigger("attack3");
            }
            else
                animator.SetTrigger("attack4");
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
    
}
