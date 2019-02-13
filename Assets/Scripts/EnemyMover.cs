using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed;
    private float moveHorizontal;

    public GameObject projectile;

    private float timeBetweenShots;
    public float fireDelay;

    [SerializeField]
    private int damage;

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
        rb.velocity = new Vector2(moveHorizontal * speed, 0.0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerCube")
        {
            //if (other.gameObject.GetComponent<IHealth>() == null)
            //{
            //    Debug.Log("No IHealth interface found on the object with an Enemy tag");
            //    return;
            //}

            other.gameObject.GetComponent<IHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

}
