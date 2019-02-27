using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    public float speed;

    public Transform dropSpot;
    public Transform exitSpot;
    public Transform eggPosition;
   

    public GameObject dragonEgg;

    private bool eggDroped;

    private float waitTime;
    public float startWaitingTime;

    //private float timeBetweenShots;
    //public float fireDelay;

    //Added 2019-02-13
    private Animator anim;


    void Start()
    {
        waitTime = startWaitingTime;
        eggDroped = false;

        //Added 2019-02-13
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        if (Vector2.Distance(transform.position, dropSpot.position) > 0.2f && eggDroped == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, dropSpot.position, speed * Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, dropSpot.position) < 0.2f && eggDroped == false)
        {
            Instantiate(dragonEgg, eggPosition.transform.position, Quaternion.identity);
            eggDroped = true;
            //Added 2019-02-13
            anim.Play("HasDropped");
        }
        if (eggDroped == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, exitSpot.position, speed * Time.deltaTime);
        }


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
}
