﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    //public float speed;

    //public Transform dropSpot;
    //public Transform exitSpot;
    public Transform eggPosition;

    
    public GameObject dragonEgg;
    //private Transform egg;
    //Added 2019-02-13
    //private Animator anim;


    void Start()
    {
      
        //Added 2019-02-13
        //anim = GetComponent<Animator>();

    }

    void Update()
    {
        //if (Vector2.Distance(transform.position, dropSpot.position) > 0.2f && eggDroped == false)
        //{
        //    transform.position = Vector2.MoveTowards(transform.position, dropSpot.position, speed * Time.deltaTime);
        //}

        //if (Vector2.Distance(transform.position, dropSpot.position) < 0.2f && eggDroped == false)
        //{
        //    Instantiate(dragonEgg, eggPosition.transform.position, Quaternion.identity);
        //    eggDroped = true;
        //    //Added 2019-02-13
        //    anim.Play("HasDropped");
        //}
        //if (eggDroped == true)
        //{
        //    transform.position = Vector2.MoveTowards(transform.position, exitSpot.position, speed * Time.deltaTime);
        //}


        //if (timeBetweenShots <= 0)
        //{
        //    Instantiate(projectile, transform.position, Quaternion.identity);
        //    timeBetweenShots = fireDelay;
        //}
        //else
        //{
        //    timeBetweenShots -= Time.deltaTime;
        //}
    }

    public void InstantiateEgg()
    {
        Instantiate(dragonEgg, eggPosition.position, Quaternion.identity);
    }
    
    //public void DetachFromParent()
    //{
    //    egg = GameObject.FindGameObjectWithTag("DragonEgg").transform;
    //    egg.parent = null;
    //    //anim = GetComponent<Animator>();
    //    //anim.SetBool("noParent", true);
    //}

}