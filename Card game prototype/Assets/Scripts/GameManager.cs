﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;
    private static bool isCreated;

    [Header("Game End")]
    public GameObject gameEndPanel;
    public TextMeshProUGUI resultText;

    [Header("Game Pause")]
    public GameObject pausePanel;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(this);
        }

        if (!isCreated)
        {
            DontDestroyOnLoad(gameObject);
            isCreated = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (FightManager.instance.player.currentHealth <= 0)
        {
            EndGame(false);
        }
        else if (FightManager.instance.enemy.currentHealth <= 0)
        {
            EndGame(true);
        }

    }
    public void EndGame(bool victory)
    {
        pausePanel.SetActive(false);

        Time.timeScale = 0;

        switch (victory)
        {
            case true:

                resultText.text = "Victory!";
                resultText.color = Color.green;
                break;
            case false:

                resultText.text = "Defeat!";
                resultText.color = Color.red;
                break;
        }

        gameEndPanel.SetActive(true);
    }

    public void RestartGameButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ConcedeButton()
    {
        EndGame(false);
    }

    public void HelpPanelButton()
    {

    }

    public void TogglePausePanelButton()
    {
        pausePanel.SetActive(!pausePanel.activeSelf);

        if (pausePanel.activeInHierarchy)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
