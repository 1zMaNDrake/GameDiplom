using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject gameOverMenu;
    public GameObject gameWinningMenu;
    public GameObject choiceMenu;
    public void EnableChoiceMenu()
    {
        choiceMenu.SetActive(true);
        Pause();
    }

    public void CloseChoiceMenu()
    {
        choiceMenu.SetActive(false);
        UnPouse();
    }
    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void UnPouse()
    {
        Time.timeScale = 1f;
    }

    public void EnableGameWinningMenu()
    {
        gameWinningMenu.SetActive(true);
    }

    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitLevel()
    {
        Application.Quit();
    }

}
