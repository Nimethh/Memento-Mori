using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialBullets : MonoBehaviour
{
    [SerializeField]
    private int numberOfProjectiles;
    [SerializeField]
    private float maxAngle;
    [SerializeField]
    private float startingAngle;
    
    [SerializeField]
    GameObject projectile;

    Vector2 instantiatePoint;
    
    Vector2 projectileDir;
    private float nextAngle;

    public float fireDelay;
    private float timeBetweenShots;
    public float speed;

    void Start()
    {
        timeBetweenShots = fireDelay;
    }
    void Update()
    {
        if (timeBetweenShots <= 0)
        {
            instantiatePoint = transform.position;
            SpawnProjectiles(numberOfProjectiles);
            timeBetweenShots = fireDelay;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
        
    }

    void SpawnProjectiles(int p_numberOfProjectiles)
    {
        nextAngle = maxAngle / numberOfProjectiles;
        float angle = startingAngle;

        for (int i = 0; i < p_numberOfProjectiles ; i++)
        {
            float projectileDirX = instantiatePoint.x + Mathf.Sin((angle * Mathf.PI) / 180);
            float projectileDirY = instantiatePoint.y + Mathf.Cos((angle * Mathf.PI) / 180);

            Vector2 projectilePos = new Vector2(projectileDirX,projectileDirY);
            Vector2 projectileMoveDir = (projectilePos - instantiatePoint).normalized * speed;

            GameObject clone = (GameObject)Instantiate(projectile, transform.position, Quaternion.identity);
            clone.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileMoveDir.x, projectileMoveDir.y);

            angle += nextAngle;
        }
    }
}
