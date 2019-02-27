using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    private float moveHorizontal;
    Rigidbody2D rb;

    [SerializeField]
    private int damage;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveHorizontal = -1;
    }

    void Update()
    {
        Vector3 pos = transform.position;
        Vector2 velocity = new Vector3(speed * Time.deltaTime, 0.0f);
        pos += transform.rotation * velocity;
        transform.position = pos;
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