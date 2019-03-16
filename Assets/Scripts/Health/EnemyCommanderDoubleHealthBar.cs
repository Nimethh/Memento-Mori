using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCommanderDoubleHealthBar : MonoBehaviour, IHealth
{
    public float health;
    //public GameObject explosion;
   private AudioSource aS;

    [SerializeField]
    private Slider healthBarRight;
    [SerializeField]
    private Slider healthBarLeft;

    void Start()
    {
        //aS = GetComponent<AudioSource>();
        health = 3000;
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
            //Destroy(gameObject);
        }
    }


    public void TakeDamage(int damage)
    {
        health = health - damage;
        //healthBar.maxValue = maxHealth;
        //healthBar.value = currentHealth;
        //aS.Play();
        healthBarRight.value = health;
        healthBarLeft.value = health;
    }

    public void TakeDamage(float damage)
    {
        health = health - damage;
        //aS.Play();
        healthBarRight.value = health;
        healthBarLeft.value = health;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
