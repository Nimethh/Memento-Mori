using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMinionHealth : MonoBehaviour, IHealth
{
    public float health;

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

    public void TakeDamage(float damage)
    {
        health = health - damage;
    }
}
