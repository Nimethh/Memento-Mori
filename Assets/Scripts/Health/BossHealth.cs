using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour, IHealth
{
    private bool isEmpActive = false;

    private GameObject EMPListener;

    public float health;
    public float secondStageHealth;
    public bool isSecondStage = false;

    void Start()
    {
        EMPListener = GameObject.Find("EMPListener");
        EMPListener.SetActive(false);
    }

    void Update()
    {
        Animator anim = GetComponent<Animator>();
        if (health <= 0 && isSecondStage)
        {
            //Instantiate(explosion, transform.position, Quaternion.identity);
            //FindObjectOfType<AudioManager>().Play("MinionDestroyed");
            //Destroy(gameObject);
        }
        if(!isEmpActive && isSecondStage && health <= secondStageHealth* 0.25f)
        {
            isEmpActive = true;
            EMPListener.SetActive(true);
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
        // Debuff for laser
        if(damage < 50f && Time.frameCount % 2 != 0)
            return;

        if(!isSecondStage)
            health -= damage;
        else {
            float healthNormalized = health / secondStageHealth;
            float lerpIndex = Mathf.Max((healthNormalized - 0.5f) * 2f, 0f);

            health -= damage * Mathf.Lerp(0.2f, 1f, Mathf.Sqrt(lerpIndex)); // square root makes sure the progression is slower
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
