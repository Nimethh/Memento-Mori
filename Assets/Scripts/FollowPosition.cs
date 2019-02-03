using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPosition : MonoBehaviour
{
    public float speed;

    //private float moveHorizontal;
    //Rigidbody rb;

    private Transform player;

    void Start()
    {
    //    rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("PlayerCube").transform;
        //moveHorizontal = -1;
    }

    void Update()
    {
        //if (transform.position.x > 8.0f)
        //    rb.velocity = new Vector3(moveHorizontal * speed, 0.0f, 0.0f);
        //else if(transform.position.x < 8.0f)
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}
