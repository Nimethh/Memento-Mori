using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverPanel;
    [SerializeField]
    private PlayerHealth playerHP;

    private bool restartLevel = false;

    void Start()
    {
        gameOverPanel.SetActive(false);
        playerHP = GameObject.Find("Player").GetComponent<PlayerHealth>();
        Time.timeScale = 1.0f;
    }

    void Update()
    {
        if(playerHP.currentHealth <= 0)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }

    public void TitleScreen()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
