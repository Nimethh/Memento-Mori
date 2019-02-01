using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    Rigidbody rb;

    public float speed;
    private float moveHorizontal;

	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        moveHorizontal = -1;
	}
    void FixedUpdate()
    {
        Vector3 enemyMovement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        rb.AddForce(enemyMovement * speed);
    }
}
