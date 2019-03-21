﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileChasing : MonoBehaviour
{
    public float speed;
    public float damage;


    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerCube").transform;
        FindObjectOfType<AudioManager>().Play("CommanderChasingBullets");
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerCube")
        {

            other.gameObject.GetComponent<IHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
