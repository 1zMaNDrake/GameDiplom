using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject gameOverMenu;
    public GameObject gameWinningMenu;
    public GameObject PauseMenu;

    private void Update()
    {
        if (Time.timeScale != 0)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                EnablePause();
            }
        }
        else
        {
            return;
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void UnPouse()
    {
        Time.timeScale = 1f;
    }

    public void MenuBack()
    {
        UnPouse();
        SceneManager.LoadScene(0);
        AudioManager.Instance.PlayMusic("Menu");
    }
    public void EnablePause()
    {
        PauseMenu.SetActive(true);
        Pause();
    }


    public void DisablePause()
    {
        PauseMenu.SetActive(false);
        UnPouse();
    }

    public void EnableGameWinningMenu()
    {
        gameWinningMenu.SetActive(true);
        Pause();
    }

    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
        Pause();
    }

    public void RestartLevel()
    {
        UnPouse();
        SceneManager.LoadScene(1);
        
    }

    public void QuitLevel()
    {
        Application.Quit();
    }

}
