using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour, IHealth
{
    public int health;
 
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }


    public void TakeDamage(int damage)
    {
        health = health - damage;
        //healthBar.maxValue = maxHealth;
        //healthBar.value = currentHealth;
    }
}
