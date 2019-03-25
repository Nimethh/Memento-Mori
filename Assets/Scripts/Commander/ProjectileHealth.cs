using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHealth : MonoBehaviour, IHealth
{
    public float health;
    public GameObject explosion;
    private Transform animPos;

    void Update()
    {
        Animator anim = GetComponent<Animator>();
        if (health <= 0)
        {
            //Animator anim = GetComponent<Animator>();
            //anim.SetTrigger("Dead");
            Instantiate(explosion, anim.gameObject.transform.position, anim.gameObject.transform.rotation);
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
