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

            //if (anim == null)
            //{
            //    Debug.Log("The Animator is null");
            //}
            //anim.SetTrigger("Dead");

            //Debug.Log("TheTriggerIsSet");
            //Debug.Log(anim.transform.position);

            Debug.Log("Instantiating" + anim.gameObject.transform.position);
            Instantiate(explosion, anim.gameObject.transform.position, anim.gameObject.transform.rotation);
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
