using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour, IHealth
{
    public float health;
    public float secondStageHealth;
    public bool isSecondStage = false;
    void Update()
    {
        Animator anim = GetComponent<Animator>();
        if (health <= 0)
        {
            //Instantiate(explosion, transform.position, Quaternion.identity);
            //FindObjectOfType<AudioManager>().Play("MinionDestroyed");
            //Destroy(gameObject);
        }
    }

    public void TakeEmp() {
        health = 0;
    }

    public void TakeDamage(int damage)
    {
        this.TakeDamage((float) damage);
    }

    // During its second stage, it gets progressively harder to deal damage (with hardest starting at 50% of damage)
    public void TakeDamage(float damage)
    {
        if(!isSecondStage)
            health -= damage;
        else {
            float healthNormalized = health / secondStageHealth;
            float lerpIndex = Mathf.Max((healthNormalized - 0.5f) * 2f, 0f);

            health -= damage * Mathf.Lerp(0.1f, 1f, Mathf.Sqrt(lerpIndex)); // square root makes sure the progression is slower
        }
        
        FindObjectOfType<AudioManager>().Play("ControlDamaged");
    }

    public float GetHealth()
    {
        return health;
    }

    public void EnterSecondStage() {
        isSecondStage = true;
        health = secondStageHealth;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
