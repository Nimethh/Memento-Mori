using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsThePlayer : MonoBehaviour
{
    private GameObject player;
    //private SpriteRenderer spriteRenderer;
    private GameObject leftArm;
    private GameObject rightArm;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerCube");
    }

    public void Update()
    {

        if (player == null)
        {
            transform.rotation = Quaternion.identity;
        }
        else
        {
            Vector3 direction = player.transform.position - transform.position;
            direction.Normalize();
            float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 180;
            transform.rotation = Quaternion.Euler(0, 0, rotationZ);

        }
    }

    public void RotateTowards()
    {
        player = GameObject.FindGameObjectWithTag("PlayerCube");
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
}
