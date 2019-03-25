using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTowards : MonoBehaviour
{
    public float speed;
    private float moveHorizontal;

    private GameObject player;
    private Vector2 playerPos;
    Rigidbody2D rb;

    [SerializeField]
    private int damage;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("PlayerCube");
        playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        moveHorizontal = -1;
        FindObjectOfType<AudioManager>().Play("CommanderBullets");
    }

    void Update()
    {
        if (player == null)
        {
            rb.velocity = new Vector2(moveHorizontal * speed, 0.0f);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);

            if (transform.position.x == playerPos.x && transform.position.y == playerPos.y)
            {
                Destroy(gameObject);
            }
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
