using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserLerp : MonoBehaviour
{
    private GameObject player;
    public float rotationSpeed;

    void Start()
    {
        player = GameObject.Find("Player");
    }
    
    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();
        float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 180;

        Quaternion Zrot = Quaternion.Euler(0, 0, rotationZ);
        //Quaternion.RotateTowards(transform.rotation, Zrot, rotationSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, Zrot, rotationSpeed * Time.deltaTime);
            //transform.rotation = Quaternion.Euler(0, 0, rotationZ);
    }
}
