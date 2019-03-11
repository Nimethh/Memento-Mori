using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolMovement : MonoBehaviour
{
    public float speed;
    public float damage;

    public Transform[] movingSpots;
    private int randomSpot;

    public GameObject projectile;
    public Transform shootingSpot;

    private float waitTime;
    public float startWaitingTime;

    private float timeBetweenShots;
    public float fireDelay;

    void Start()
    {
        randomSpot = Random.Range(0, movingSpots.Length);
        waitTime = startWaitingTime;
        timeBetweenShots = fireDelay;
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

        if (timeBetweenShots <= 0)
        {
            Instantiate(projectile, shootingSpot.position, transform.rotation);
            timeBetweenShots = fireDelay;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
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
