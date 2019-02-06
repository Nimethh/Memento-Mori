using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    Rigidbody rb;

    public float speed;
    private float moveHorizontal;

    public GameObject projectile;

    private float timeBetweenShots;
    public float fireDelay;

	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        moveHorizontal = -1;
        timeBetweenShots = fireDelay;
        //Physics.IgnoreCollision(GetComponent<Collider>(), projectile.GetComponent<Collider>());
	}

    public void Update()
    {
       if(timeBetweenShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBetweenShots = fireDelay;
        }
       else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(moveHorizontal * speed, 0.0f, 0.0f);
    }

}
