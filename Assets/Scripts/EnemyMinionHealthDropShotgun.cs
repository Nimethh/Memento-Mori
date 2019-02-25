using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMinionHealthDropShotgun : MonoBehaviour, IHealth
{
    [SerializeField]
    private float health;

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            GameObject weapon = (GameObject)Instantiate(Resources.Load<GameObject>("WeaponCrates/ShotgunCrate"), transform.position, transform.rotation);

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
