using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsThePlayer : MonoBehaviour
{
    private GameObject player;
    private SpriteRenderer spriteRenderer;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("PlayerCube");
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}

    public void Update()
    {
       
        if (player == null)
        {
            transform.rotation = Quaternion.identity;
        }
        else
        {
            Vector3 direction = player.transform.position - transform.position;
            direction.Normalize();
            float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 180;
            transform.rotation = Quaternion.Euler(0, 0, rotationZ);
            if (rotationZ > -280 && rotationZ < -80)
            {
                spriteRenderer.flipY = true;
            }
            else
                spriteRenderer.flipY = false;
        }
    }
}
