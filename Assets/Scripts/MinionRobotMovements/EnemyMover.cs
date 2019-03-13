using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sp;

    public float speed;
    public float damage;
    private float moveHorizontal;

    public GameObject projectile;
    public Transform shootingSpot;

    private float timeBetweenShots;
    public float fireDelay;
    private AudioSource shootingSound;

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        moveHorizontal = -1;
        timeBetweenShots = fireDelay;
        shootingSound = GetComponent<AudioSource>();
	}

    public void Update()
    {
       if(timeBetweenShots <= 0)
        {
            Instantiate(projectile, shootingSpot.position, shootingSpot.rotation);
            shootingSound.Play();
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
