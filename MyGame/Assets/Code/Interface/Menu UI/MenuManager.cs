using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject almanacPanel;
    [SerializeField] private GameObject aboutGamePanel;
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

    public void AlmanacPanelOpen()
    {
        almanacPanel.SetActive(true);
    }
    public void AlmanacPanelClose()
    {
        almanacPanel.SetActive(false);
    }

    public void AboutGamePanelOpen()
    {
        aboutGamePanel.SetActive(true);
    }
    public void AboutGameClose()
    {
        aboutGamePanel.SetActive(false);
    }
}
