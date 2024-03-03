using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject gameOverMenu;

  
    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    } 


    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
        EnemySpawn.spawnCount = 0;
    }
}
