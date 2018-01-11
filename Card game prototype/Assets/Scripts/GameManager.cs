using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject gameEndPanel;
    public TextMeshProUGUI resultText;

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

}
