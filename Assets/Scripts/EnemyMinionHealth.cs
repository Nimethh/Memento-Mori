using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMinionHealth : MonoBehaviour, IHealth
{
    private float maxHealth;
    [SerializeField]
    private float currentHealth;

    void Start()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
    }

    void Update()
    {
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }

    public void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;
    }

    public void TakeDamage(float damage)
    {
        currentHealth = currentHealth - damage;
    }
}
