using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWithExplosion : MonoBehaviour
{
    public GameObject explosion;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }

        if (other.tag == "Projectile")
        {
            return;
        }

        if (other.tag == "PlayerCube")
        {
            Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
