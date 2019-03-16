using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IHealth
{

    [SerializeField]
    private Animator anim;
    [SerializeField]
    private CameraShake cameraShake;

    [SerializeField]
    private int lives;
    [SerializeField]
    private bool isInvulnerable;
    [SerializeField]
    private float invulnerabilityCounter;
    [SerializeField]
    private float invulnerabilityTime;


    [SerializeField]
    private int maxHealth;
    public float currentHealth;
    [SerializeField]
    private Slider healthBar;
    [SerializeField]
    private GameObject gameOverPanel;

    void Start()
    {
        anim = GetComponent<Animator>();
        lives = 0;
        isInvulnerable = false;
        invulnerabilityTime = 3f;
        maxHealth = 200;
        currentHealth = maxHealth;
        healthBar.value = currentHealth;

    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            //Debug.Log("Player has died");
            if (lives == 0)
            {
                //Debug.Log("GameOver");
                //SceneManager.LoadScene("DeathScreen");

            }
            else
            {
                lives--;
                currentHealth = maxHealth;
                isInvulnerable = true;
                invulnerabilityCounter = invulnerabilityTime;
                healthBar.value = currentHealth;
                anim.SetTrigger("LostALife");

            }
        }

        if (invulnerabilityCounter > 0)
        {
            invulnerabilityCounter -= Time.deltaTime;
            if (invulnerabilityCounter <= 0)
            {
                //Debug.Log("invulnerability ran out");
                invulnerabilityCounter = 0; //looks cleaner in the inspector
                isInvulnerable = false;
            }
        }

    }

    public void TakeDamage(int damage)
    {
        if (isInvulnerable)
        {
            return;
        }
        else
        {
            currentHealth = currentHealth - damage;
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
            StartCoroutine(cameraShake.Shake(0.2f, 0.1f));

        }
    }

    public void TakeDamage(float damage)
    {

        if (isInvulnerable)
        {
            return;
        }
        else
        {
            currentHealth = currentHealth - damage;
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;

            StartCoroutine(cameraShake.Shake(0.2f, 0.1f));

        }
    }
    
}