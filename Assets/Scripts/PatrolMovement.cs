using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolMovement : MonoBehaviour
{
    public float speed;

    public Transform[] movingSpots;
    private int randomSpot;

    public GameObject projectile;

    private float waitTime;
    public float startWaitingTime;

    private float fireProjectile;
    public float fireDelay;

    void Start()
    {
        randomSpot = Random.Range(0, movingSpots.Length);
        waitTime = startWaitingTime;
        fireProjectile = fireDelay;
    }
    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movingSpots[randomSpot].position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, movingSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, movingSpots.Length);
                waitTime = startWaitingTime;
            }
            else
                waitTime -= Time.deltaTime;
        }

        if (fireProjectile <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            fireProjectile = fireDelay;
        }
        else
        {
            fireProjectile -= Time.deltaTime;
        }
    }
}
