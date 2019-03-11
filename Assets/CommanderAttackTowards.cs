using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommanderAttackTowards : MonoBehaviour
{
    private Transform player;
    public GameObject projectile;
    public float fireDelay;
    private float timeBetweenShots;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerCube").transform;
        timeBetweenShots = fireDelay;
    }

    void Update()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 180;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
        if (timeBetweenShots <= 0)
        {
            Instantiate(projectile, transform.position, transform.rotation);
            timeBetweenShots = fireDelay;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }
}
