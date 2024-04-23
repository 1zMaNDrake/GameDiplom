using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject settingsPanel;


    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void SettingsPanelOpen()
    {
            settingsPanel.SetActive(true);
    }
    public void SettingsPanelClose()
    {
        settingsPanel.SetActive(false);
    }
}
