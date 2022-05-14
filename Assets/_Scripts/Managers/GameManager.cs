using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance;
    public int enemyDestroyed = 0;
    public GameObject gameOverPanel;
    public GameObject gameWinPanel;

    
    
    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(sharedInstance);
        }
    }

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (enemyDestroyed >= 10)
        {
            GameWin();
        }
    }

    private void GameWin()
    {
        gameWinPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void EnemySelected(GameObject enemy)
    {
        
    }
}
