using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinusoidalMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float damage;
    
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private Transform shootingSpot;

    private float timeBetweenShots;
    [SerializeField]
    private float fireDelay;

    public Transform[] movingSpots;
    private int fixedSpot;

    void Start()
    {
        fixedSpot = 0;
        timeBetweenShots = fireDelay;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movingSpots[fixedSpot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, movingSpots[fixedSpot].position) < 0.1f)
        {
            fixedSpot++;
            if(fixedSpot > movingSpots.Length - 1)
            {
                Destroy(gameObject);
            }
        }
        if (timeBetweenShots <= 0)
        {
            Instantiate(projectile, shootingSpot.position, Quaternion.identity);
            timeBetweenShots = fireDelay;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }
}

