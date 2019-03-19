using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMinionHealth : MonoBehaviour, IHealth
{
    public float health;
    public GameObject explosion;
    
    void Update()
    {
        Animator anim = GetComponent<Animator>();
        if (health <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            //FindObjectOfType<AudioManager>().Play("MinionDestroyed");
            Destroy(gameObject);
        }
    }


    public void TakeDamage(int damage)
    {
        health = health - damage;
        FindObjectOfType<AudioManager>().Play("MinionDamaged");

    }

    public void TakeDamage(float damage)
    {
        health = health - damage;
        FindObjectOfType<AudioManager>().Play("MinionDamaged");
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
