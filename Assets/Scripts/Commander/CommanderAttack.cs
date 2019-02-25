using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommanderAttack : MonoBehaviour
{
    public GameObject projectile;
    public float fireDelay;
    private float timeBetweenShots;

    void Start()
    {
        timeBetweenShots = fireDelay;
    }
    void Update()
    {
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
