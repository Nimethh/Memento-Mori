using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateArmsTowards : StateMachineBehaviour
{
    private Transform player;
    private GameObject leftArm;
    private GameObject rightArm;
    private RotateTowardsThePlayer rt;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetTrigger("moving");
    }
    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("PlayerCube").transform;
        leftArm = GameObject.FindGameObjectWithTag("CommanderLeftArm");
        rightArm = GameObject.FindGameObjectWithTag("CommanderRightArm");
        if (leftArm == null)
        {
            Debug.Log("Couldn't find leftArm object");
        }
        rightArm = GameObject.FindGameObjectWithTag("CommanderRightArm");
        if (rightArm == null)
        {
            Debug.Log("Couldn't find rightArm object");
        }
        Vector3 leftDirection = player.transform.position - leftArm.transform.position;
        Vector3 rightDirection = player.transform.position - rightArm.transform.position;
        leftDirection.Normalize();
        rightDirection.Normalize();
        float leftRotationZ = Mathf.Atan2(leftDirection.y, leftDirection.x) * Mathf.Rad2Deg + 90;
        float rightRotationZ = Mathf.Atan2(rightDirection.y, rightDirection.x) * Mathf.Rad2Deg + 90;

        leftArm.transform.rotation = Quaternion.Euler(0, 0, leftRotationZ);
        rightArm.transform.rotation = Quaternion.Euler(0, 0, rightRotationZ);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
    
}
