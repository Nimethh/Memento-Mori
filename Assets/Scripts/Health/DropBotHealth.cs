using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBotHealth : MonoBehaviour, IHealth
{
    public float health;
    public GameObject explosion;
    private Transform animPos;
    
    void Update()
    {
        Animator anim = GetComponent<Animator>();

        if (health <= 0)
        {
            Instantiate(explosion, anim.gameObject.transform.position, anim.gameObject.transform.rotation);
            FindObjectOfType<AudioManager>().Play("DropBotDestroyed");
            Destroy(gameObject);
        }
    }


    public void TakeDamage(int damage)
    {
        health = health - damage;
        FindObjectOfType<AudioManager>().Play("DropBotDamaged");
    }

    public void TakeDamage(float damage)
    {
        health = health - damage;
        FindObjectOfType<AudioManager>().Play("DropBotDamaged");
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
    
}
