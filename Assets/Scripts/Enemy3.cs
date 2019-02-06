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

    void Start()
    {
        waitTime = startWaitingTime;
        eggDroped = false;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, dropSpot.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, dropSpot.position) < 0.2f && eggDroped == false)
        {
            Instantiate(dragonEgg, eggPosition.transform.position, Quaternion.identity);
            eggDroped = true;
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
