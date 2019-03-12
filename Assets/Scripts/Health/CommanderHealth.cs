using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommanderHealth : MonoBehaviour, IHealth
{
    public float health;
    //public GameObject explosion;
   

    void Update()
    {
        
        if (health <= 0)
        {

            //Animator anim = GetComponent<Animator>();
            //anim.SetTrigger("Dead");
            //Debug.Log("TheTriggerIsSet");
            //Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }


    public void TakeDamage(int damage)
    {
        health = health - damage;
        //healthBar.maxValue = maxHealth;
        //healthBar.value = currentHealth;
    }

    public void TakeDamage(float damage)
    {
        health = health - damage;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
