using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFixedPathMovement : MonoBehaviour
{
    public float speed;
    public float damage;

    public Transform[] movingSpots;
    private int fixedSpot;

    public GameObject projectile;

    private float waitTime;
    public float startWaitingTime;

    private float timeBetweenShots;
    public float fireDelay;
    public float maxRandomFireDelayModifier;
    public float minRandomFireDelayModifier;

    void Start()
    {
        fixedSpot = 0;
        waitTime = startWaitingTime;
        //timeBetweenShots = fireDelay;
        timeBetweenShots = fireDelay + Random.Range(minRandomFireDelayModifier, maxRandomFireDelayModifier);

    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movingSpots[fixedSpot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, movingSpots[fixedSpot].position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                fixedSpot++;
                //Instantiate(projectile, transform.position, Quaternion.identity);

                if (fixedSpot + 1 > movingSpots.Length)
                {
                    fixedSpot = 0;
                }

                waitTime = startWaitingTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        if (timeBetweenShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBetweenShots = fireDelay + Random.Range(minRandomFireDelayModifier,maxRandomFireDelayModifier);
            Debug.Log(timeBetweenShots);
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
