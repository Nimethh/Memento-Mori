using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour/*, IHealth*/
{
    
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
    [SerializeField]
    private int currentHealth;

    public Image healthBar;

    void Start()
    {
        lives = 3;
        isInvulnerable = false;
        invulnerabilityTime = 3f;
        maxHealth = 100;
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            Debug.Log("Player has died");
            if (lives == 0)
            {
                Debug.Log("GameOver");
                SceneManager.LoadScene("DeathScreen");

            }
            else
            {
                lives--;
                isInvulnerable = true;
                invulnerabilityCounter = invulnerabilityTime;
                currentHealth = maxHealth;
            }
        }

        if (invulnerabilityCounter > 0)
        {
            invulnerabilityCounter -= Time.deltaTime;
            if (invulnerabilityCounter <= 0)
            {
                Debug.Log("invulnerability ran out");
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
            healthBar.fillAmount = currentHealth / maxHealth;
        }
    }
}
