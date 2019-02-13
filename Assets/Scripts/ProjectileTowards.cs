using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTowards : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector2 playerPos;

    [SerializeField]
    private int damage;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerCube").transform;
        playerPos = new Vector2(player.position.x, player.position.y);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);

        if (transform.position.x == playerPos.x && transform.position.y == playerPos.y)
        {
            Destroy(gameObject);
        }
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
