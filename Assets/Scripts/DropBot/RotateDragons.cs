using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDragons : MonoBehaviour
{
    private GameObject player;
    private SpriteRenderer sp;

    void Start()
    {
        player = GameObject.Find("Player");
        sp = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();
        float rotationZ = Mathf.Atan2(direction.y , direction.x) * Mathf.Rad2Deg + 180;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
        if (rotationZ >= 85 && rotationZ <= 275)
        {
            sp.flipY = true;
        }
        else
            sp.flipY = false;
    }
}
