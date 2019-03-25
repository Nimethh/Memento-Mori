using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommanderHealth : MonoBehaviour, IHealth
{
    public float health;

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
        FindObjectOfType<AudioManager>().Play("CommanderDamaged");
    }

    public void TakeDamage(float damage)
    {
        health = health - damage;
        FindObjectOfType<AudioManager>().Play("CommanderDamaged");
    }

    public float GetHealth()
    {
        return health;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void PlayLaserSound()
    {
        FindObjectOfType<AudioManager>().Play("CommanderLaser");
    }

    public void PlayDeathSound()
    {
        FindObjectOfType<AudioManager>().Play("CommanderDestroyed");
    }
}
