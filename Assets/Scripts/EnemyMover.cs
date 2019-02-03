using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    Rigidbody rb;

    public float speed;
    private float moveHorizontal;

    public GameObject projectile;

    private float fireProjectile;
    public float fireDelay;

	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        moveHorizontal = -1;
        fireProjectile = fireDelay;
        //Physics.IgnoreCollision(GetComponent<Collider>(), projectile.GetComponent<Collider>());
	}

    public void Update()
    {
       if(fireProjectile <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            fireProjectile = fireDelay;
        }
       else
        {
            fireProjectile -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(moveHorizontal * speed, 0.0f, 0.0f);
        //transform.position = transform.position + transform.forward * Time.deltaTime;
        //Vector3 enemyMovement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        //rb.AddForce(enemyMovement * speed);
    }

}
