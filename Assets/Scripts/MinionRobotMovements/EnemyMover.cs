using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed;
    public float damage;
    private float moveHorizontal;

    public GameObject projectile;
    public Transform shootingSpot;

    private float timeBetweenShots;
    public float fireDelay;

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        moveHorizontal = -1;
        timeBetweenShots = fireDelay;
	}

    public void Update()
    {
       if(timeBetweenShots <= 0)
        {
            Instantiate(projectile, shootingSpot.position, shootingSpot.rotation);
            timeBetweenShots = fireDelay;
        }
       else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveHorizontal * speed, 0.0f);
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
