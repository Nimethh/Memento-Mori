using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject credits;
    public GameObject mainMenu;

    public void NewGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Back()
    {
        mainMenu.SetActive(true);
        credits.SetActive(false);
    }

    public void Credits()
    {
        mainMenu.SetActive(false);
        credits.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
