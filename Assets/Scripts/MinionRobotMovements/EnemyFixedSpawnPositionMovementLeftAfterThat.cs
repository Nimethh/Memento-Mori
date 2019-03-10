using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFixedSpawnPositionMovementLeftAfterThat : MonoBehaviour
{
    public float speed;
    public float damage;

    public Transform[] movingSpots;
    private int fixedSpot;

    public GameObject projectile;
    public Transform shootingSpot;

    private float waitTime;
    public float startWaitingTime;

    private float timeBetweenShots;
    public float fireDelay;
    public float maxRandomFireDelayModifier;
    public float minRandomFireDelayModifier;

    [SerializeField]
    private bool hasMovedToMovingSpot;
    private Rigidbody2D rigid;
    int randomSpot;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        hasMovedToMovingSpot = false;
        fixedSpot = 0;
        waitTime = startWaitingTime;
        //timeBetweenShots = fireDelay;
        timeBetweenShots = fireDelay + Random.Range(minRandomFireDelayModifier, maxRandomFireDelayModifier);
        randomSpot = Random.Range(0, movingSpots.Length);

    }

    void Update()
    {
        if(hasMovedToMovingSpot == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, movingSpots[randomSpot].position, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, movingSpots[randomSpot].position) < 0.1f)
            {
                hasMovedToMovingSpot = true;
                rigid.velocity = transform.right * speed;
            }
        }
        

        if (timeBetweenShots <= 0)
        {
            Instantiate(projectile, shootingSpot.position, transform.rotation);
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
