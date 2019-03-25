using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplittingBullet : MonoBehaviour,IHealth
{
    public float speed;
    public float damage;
    public float health;

    public GameObject projectile;
    public Transform[] instantiationSpots;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerCube").transform;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        if (health <= 0)
        {
            for (int i = 0; i < instantiationSpots.Length; i++)
                Instantiate(projectile, instantiationSpots[i].transform.position, Quaternion.identity);
            Destroy(gameObject);
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

    public void TakeDamage(int damage)
    {
        health = health - damage;
    }

    public void TakeDamage(float damage)
    {
        health = health - damage;
    }

    public float GetHealth()
    {
        return health;
    }
}
