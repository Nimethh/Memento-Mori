using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPosition : MonoBehaviour
{
    public float speed;
    
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerCube").transform;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}
