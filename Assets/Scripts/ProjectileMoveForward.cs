using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMoveForward : MonoBehaviour
{
    public float speed;
    private float moveHorizontal;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveHorizontal = -1;
    }


    void Update()
    {
        rb.velocity = new Vector3(moveHorizontal * speed, 0.0f, 0.0f);
    }
}
