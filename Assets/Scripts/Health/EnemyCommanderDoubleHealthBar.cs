using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCommanderDoubleHealthBar : MonoBehaviour, IHealth
{
    public float health;
    //public GameObject explosion;

    [SerializeField]
    private Slider healthBarRight;
    [SerializeField]
    private Slider healthBarLeft;

    void Start()
    {
        healthBarRight.maxValue = health;
        healthBarLeft.maxValue = health;
        healthBarRight.value = health;
        healthBarLeft.value = health;

    }

    void Update()
    {
        
        if (health <= 0)
        {

            //Animator anim = GetComponent<Animator>();
            //anim.SetTrigger("Dead");
            //Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }


    public void TakeDamage(int damage)
    {
        health = health - damage;

        healthBarRight.value = health;
        healthBarLeft.value = health;
        FindObjectOfType<AudioManager>().Play("CommanderDamaged");
    }

    public void TakeDamage(float damage)
    {
        health = health - damage;
        healthBarRight.value = health;
        healthBarLeft.value = health;
        FindObjectOfType<AudioManager>().Play("CommanderDamaged");
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
