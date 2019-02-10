using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMoveForward : MonoBehaviour
{
    public float speed;
    private float moveHorizontal;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveHorizontal = -1;
    }


    void Update()
    {
        rb.velocity = new Vector2(moveHorizontal * speed, 0.0f);
    }
}
