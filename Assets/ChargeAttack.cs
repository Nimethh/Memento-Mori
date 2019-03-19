using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeAttack : StateMachineBehaviour
{
    private Transform endPos;
    private Transform startPos;
    [SerializeField]
    private float chargeSpeed;
    [SerializeField]
    private float backSpeed;
    
    private GameObject chargePos;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        endPos.position = new Vector2(-3.5f, 0f );
        startPos.position = new Vector2(4.3f, 0f);
        chargePos.transform.position = GameObject.Find("ChargePos").transform.position;
    }
    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(chargePos == null)
        {
            Debug.Log("Couldn't find the object");
        }
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, endPos.position, chargeSpeed * Time.deltaTime);
        if(Vector2.Distance(animator.transform.position,endPos.position) <= 0.1f )
        {
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, startPos.position, backSpeed * Time.deltaTime);
        }
    }
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
    
}
