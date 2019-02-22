using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommanderBehaviorTest1 : MonoBehaviour
{
    //public float speed;

    //public Transform movingSpot;
    //public float minX;
    //public float maxX;
    //public float minY;
    //public float maxY;

    public GameObject projectile; //Changed in the inspector 2019-02-18

    //private float waitTime;
    //public float startWaitingTime;

    private float timeBetweenShots;
    public float fireDelay;

    void Start()
    {
        //movingSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        //waitTime = startWaitingTime;
        timeBetweenShots = fireDelay;
    }

    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, movingSpot.position, speed * Time.deltaTime);

        //if (Vector2.Distance(transform.position, movingSpot.position) < 0.2f)
        //{
        //    if (waitTime <= 0)
        //    {
        //        movingSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        //        waitTime = startWaitingTime;
        //    }
        //    else
        //        waitTime -= Time.deltaTime;
        //}

        if (timeBetweenShots <= 0)
        {
            //Instantiate(projectile, transform.position, Quaternion.identity);
            StartCoroutine("FireBurst"); //Added 2019-02-18
            timeBetweenShots = fireDelay;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }

    //Added 2019-02-18
    IEnumerator FireBurst()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);

            yield return new WaitForSeconds(.3f);
        }
    }

}
