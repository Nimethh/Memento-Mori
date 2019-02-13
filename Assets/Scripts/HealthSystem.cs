using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int health;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Bullet")
        {
            health -= 10;
            Debug.Log("EnemyHp : " + health);
            Destroy(other.gameObject);
        }
        //else if (other.tag == "MinionProjectile")
        //{
        //    if (other.tag == "RandomMinion" || other.tag == "Commander" || other.tag == "Enemy3" || other.tag == "FollowMinion" )
        //    {
        //        return;
        //    }
        //    health -= 5;
        //    Debug.Log("PlayerHp :" + health);
        //}
        //else if (other.tag == "FollowMinion")
        //{
        //    if (other.tag == "MinionProjectile" || other.tag == "Projectile")
        //    {
        //        return;
        //    }
        //    health -= 20;
        //    Debug.Log("PlayerHp : " + health);
        //}
        //else if (other.tag == "RandomMinion")
        //{
        //    if (other.tag == "MinionProjectile" || other.tag == "Projectile")
        //    {
        //        return;
        //    }
        //    health -= 10;
        //    Debug.Log("PlayerHp : " + health);
        //}
        //else if (other.tag == "Dragon")
        //{
        //    if (other.tag == "MinionProjectile" || other.tag == "Projectile" || other.tag == "RandomMinion" || other.tag == "Commander" || other.tag == "Enemy3" || other.tag == "FollowMinion")
        //    {
        //        return;
        //    }
        //    health -= 25;
        //    Debug.Log("PlayerHp : " + health);
        //}
        //else if (other.tag == "Projectile")
        //{
        //    if (other.tag == "RandomMinion" || other.tag == "Commander" || other.tag == "Enemy3" || other.tag == "FollowMinion" )
        //    {
        //        return;
        //    }
        //    health -= 30;
        //    Debug.Log("PlayerHp : " + health);
        //}

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
