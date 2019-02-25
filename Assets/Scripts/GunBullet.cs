﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBullet : MonoBehaviour
{

//    private Transform transform;
    [SerializeField]
    private float speed;
    [SerializeField]
    private int damage;
    [SerializeField]
    private float lifetime = 5f;

    private Rigidbody2D rigid;


    void Start()
    {
        //transform = GetComponent<Transform>();
        rigid = GetComponent<Rigidbody2D>();
        speed = 20f;
        rigid.velocity = transform.right * speed;

    }

    void Update()
    {
        //transform.position = transform.position + (transform.right * speed);
        lifetime -= Time.deltaTime;

        if(lifetime <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("OnTriggerEnter2D() - GunBullet");

        if (collision.gameObject.tag == "Enemy")
        {
            if (collision.gameObject.GetComponent<IHealth>() == null)
            {
                Debug.Log("No IHealth interface found on the object with an Enemy tag - Called from GunBullet");
                return;
            }

            collision.gameObject.GetComponent<IHealth>().TakeDamage(damage);
            Destroy(this.gameObject);

        }
    }
}
